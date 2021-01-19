using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using MediatR;
using Persistence.DapperConnection.Productos;

namespace Application.Producto
{
    public class Delete
    {
        public class RunDelete : IRequest
        {
            public Guid ProductoId { get; set; }
        }

        public class Handler : IRequestHandler<RunDelete>
        {
            private readonly IProductoRepository _productoRepository;
            public Handler(IProductoRepository productoRepository)
            {
                this._productoRepository = productoRepository;
            }
            public async Task<Unit> Handle(RunDelete request, CancellationToken cancellationToken)
            {
                var producto = await _productoRepository.Get(request.ProductoId);

                if (producto == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No se encontro el Producto" });
                }

                var result = await _productoRepository.Delete(request.ProductoId);

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo Eliminar el Producto");
            }
        }
    }
}