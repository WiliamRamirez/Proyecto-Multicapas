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
using Persistence.DapperConnection.Combos;
using Persistence.DapperConnection.Productos;

namespace Application.Producto
{
    public class GetId
    {
        public class RunGetId : IRequest<ProductoDTO>
        {
            public Guid ProductoId { get; set; }
        }

        public class Handler : IRequestHandler<RunGetId,ProductoDTO>
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
            public async Task<ProductoDTO> Handle(RunGetId request, CancellationToken cancellationToken)
            {
                var producto = await _productoRepository.Get(request.ProductoId);

                if (producto == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No se encontro el Producto" });
                }

                ProductoDTO productoDTO = null;
                productoDTO = _mapper.Map<ProductoDTO>(producto);

                var resultCombo = await _comboRepository.Get(productoDTO.ProductoId);
                var comboDTO = _mapper.Map<List<ComboDTO>>(resultCombo.ToList());
                productoDTO.Combos = comboDTO;

                return productoDTO;

            }
        }
    }
}