using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence.DapperConnection.Compras;
using Persistence.DapperConnection.DetallesCompras;

namespace Application.Compra
{
    public class Get
    {
        public class RunGet : IRequest<List<CompraDTO>>
        {

        }

        public class Handler : IRequestHandler<RunGet, List<CompraDTO>>
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
            public async Task<List<CompraDTO>> Handle(RunGet request, CancellationToken cancellationToken)
            {
                var resultCompras = await _compraRepository.Get();

                var listCompraDTO = new List<CompraDTO>();
                listCompraDTO = _mapper.Map<List<CompraDTO>>(resultCompras.ToList());

                foreach (var compra in listCompraDTO)
                {
                    var resultDetalleCompra = await _detalleCompraRepository.Get(compra.CompraId);
                    var detalleCompraDTO = _mapper.Map<List<DetalleCompraDTO>>(resultDetalleCompra.ToList());
                    compra.DetallesCompras = detalleCompraDTO;
                }
                return listCompraDTO;
            }
        }
    }
}