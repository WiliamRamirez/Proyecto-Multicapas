using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using FluentValidation;
using MediatR;
using Persistence.DapperConnection.Compras;
using Persistence.DapperConnection.DetallesCompras;

namespace Application.Compra
{
    public class Post
    {
        public class RunPost : IRequest
        {
            public DateTime FechaCompra { get; set; }
            public string TipoComprobante { get; set; }
            public string Serie { get; set; }
            public Decimal Correlativo { get; set; }
            public Decimal Igv { get; set; }
            public Decimal Descuento { get; set; }
            public Guid ProveedorId { get; set; }
            public List<DetalleCompraCreationDTO> DetallesCompras { get; set; }
        }
        public class RunPostValidation : AbstractValidator<RunPost>
        {
            public RunPostValidation()
            {
                RuleFor(x => x.FechaCompra).NotEmpty();
                RuleFor(x => x.TipoComprobante).NotEmpty();
                RuleFor(x => x.Serie).NotEmpty();
                RuleFor(x => x.Correlativo).NotEmpty();
                RuleFor(x => x.Igv).NotEmpty();
                RuleFor(x => x.Descuento).NotEmpty();
                RuleFor(x => x.ProveedorId).NotEmpty();
                RuleFor(x => (x.DetallesCompras)).NotEmpty();
               
            }
        }

        public class Handler : IRequestHandler<RunPost>
        {
            private readonly ICompraRepository _compraRepository;
            private readonly IDetalleCompraRepository _detalleCompraRepository;

            public Handler(ICompraRepository compraRepository, IDetalleCompraRepository detalleCompraRepository)
            {
                this._detalleCompraRepository = detalleCompraRepository;
                this._compraRepository = compraRepository;

            }
            public async Task<Unit> Handle(RunPost request, CancellationToken cancellationToken)
            {
                var _compraId = Guid.NewGuid();

                var compraModel = new CompraModel {
                    CompraId = _compraId,
                    FechaCompra = request.FechaCompra,
                    TipoComprobante = request.TipoComprobante,
                    Serie = request.Serie,
                    Correlativo = request.Correlativo,
                    Igv = request.Igv,
                    Descuento = request.Descuento,
                    ProveedorId = request.ProveedorId,
                };

                var resultCompra = await _compraRepository.Post(compraModel);
                int resultDetalleCompra = 0;

                foreach (var detalleCompra in request.DetallesCompras)
                {
                    var detalleCompraModel = new DetalleCompraModel
                    {
                        Cantidad = detalleCompra.Cantidad,
                        PrecioUnitario = detalleCompra.PrecioUnitario,
                        SubTotal = detalleCompra.SubTotal,
                        CompraId = _compraId,
                        ProductoId = detalleCompra.ProductoId,
                    };

                    var result = await _detalleCompraRepository.Post(detalleCompraModel);
                    resultDetalleCompra += result;


                }

                if (resultDetalleCompra > 0 && resultCompra > 0)
                {
                    return Unit.Value;
                }

                if (resultDetalleCompra <= 0)
                {
                    throw new Exception("No se pudo agregar detalla Compra");
                }

                throw new Exception("No se pudo agregar la Compra");
            
            }
        }
    }
}