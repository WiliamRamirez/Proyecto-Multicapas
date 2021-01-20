using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.ExceptionHandler;
using AutoMapper;
using MediatR;
using Persistence.DapperConnection.Compras;
using Persistence.DapperConnection.DetallesCompras;

namespace Application.Compra
{
    public class GetId
    {
        public class RunGetId : IRequest<CompraDTO>
        {
            public Guid CompraId { get; set; }
        }

        public class Handler : IRequestHandler<RunGetId, CompraDTO>
        {
            private readonly ICompraRepository _compraRepository;
            private readonly IDetalleCompraRepository _detalleCompraRepository;
            private readonly IMapper _mapper;

            public Handler(ICompraRepository compraRepository, IDetalleCompraRepository detalleCompraRepository, IMapper mapper)
            {
                this._compraRepository = compraRepository;
                this._detalleCompraRepository = detalleCompraRepository;
                this._mapper = mapper;
            }
            public async  Task<CompraDTO> Handle(RunGetId request, CancellationToken cancellationToken)
            {

                var producto = await _compraRepository.Get(request.CompraId);

                if (producto == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No se encontro el Producto" });
                }

                var compraDTO = new CompraDTO();
                compraDTO = _mapper.Map<CompraDTO>(producto);

                var resultDetalleCompra = await _detalleCompraRepository.Get(compraDTO.CompraId);
                var detalleCompraDTO = _mapper.Map<List<DetalleCompraDTO>>(resultDetalleCompra.ToList());
                compraDTO.DetallesCompras = detalleCompraDTO;

                return compraDTO;
            }
        }
    }
}