using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence.DapperConnection.Combos;
using Persistence.DapperConnection.Productos;

namespace Application.Producto
{
    public class Get
    {
        public class RunGet : IRequest<List<ProductoDTO>>
        {

        }

        public class Handler : IRequestHandler<RunGet, List<ProductoDTO>>
        {
            private readonly IProductoRepository _productoRepository;
            private readonly IMapper _mapper;
            private readonly IComboRepository _comboRepository;

            public Handler(IProductoRepository productoRepository, IMapper mapper, IComboRepository comboRepository)
            {
                this._comboRepository = comboRepository;
                this._productoRepository = productoRepository;
                this._mapper = mapper;
            }
            public async Task<List<ProductoDTO>> Handle(RunGet request, CancellationToken cancellationToken)
            {
                var resultProducto = await _productoRepository.Get();

                List<ProductoDTO> listProductoDTO = null;
                listProductoDTO = _mapper.Map<List<ProductoDTO>>(resultProducto.ToList());
                
                foreach (var producto in listProductoDTO)
                {
                    var resultCombo = await _comboRepository.Get(producto.ProductoId);
                    var comboDTO = _mapper.Map<List<ComboDTO>>(resultCombo.ToList());
                    producto.Combos = comboDTO;
                }

                return listProductoDTO;
            }
        }


    }
}