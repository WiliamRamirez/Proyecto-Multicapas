using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using MediatR;
using Persistence.DapperConnection.Productos;

namespace Application.Producto
{
    public class Put
    {
        public class RunPut : IRequest
        {
            public Guid ProductoId { get; set; }
            public string NombreProducto { get; set; }
            public string Descripcion { get; set; }
            // public int Stock { get; set; }
            public Decimal? PrecioVenta { get; set; }
            public Guid? CategoriaId { get; set; }
        }

        public class Handler : IRequestHandler<RunPut>
        {
            private readonly IProductoRepository _productoRepository;
            public Handler(IProductoRepository productoRepository)
            {
                this._productoRepository = productoRepository;
            }
            public async Task<Unit> Handle(RunPut request, CancellationToken cancellationToken)
            {
                var producto = await _productoRepository.Get(request.ProductoId);

                if (producto == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No se encontro el Producto" });
                }

                var productoModel = new ProductoModel
                {
                    ProductoId = request.ProductoId,
                    NombreProducto = request.NombreProducto ?? producto.NombreProducto,
                    Descripcion = request.Descripcion ?? producto.Descripcion,
                    // Stock = request.Stock,
                    PrecioVenta = request.PrecioVenta ?? producto.PrecioVenta,
                    CategoriaId = request.CategoriaId ?? producto.CategoriaId
                };

                var result = await _productoRepository.Put(productoModel);

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo actualizar el Producto");


            }
        }
    }
}