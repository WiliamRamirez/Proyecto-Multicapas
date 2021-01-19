using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistence.DapperConnection.Productos;

namespace Application.Producto
{
    public class Post
    {
        public class RunPost : IRequest
        {
            public string NombreProducto { get; set; }
            public string Descripcion { get; set; }
            public int? Stock { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Guid CategoriaId { get; set; }
        }

        public class RunPostValidation : AbstractValidator<RunPost>
        {
            public RunPostValidation()
            {
                RuleFor(x => x.NombreProducto).NotEmpty();
                RuleFor(x => x.Stock).NotEmpty();
                RuleFor(x => x.PrecioVenta).NotEmpty();
                RuleFor(x => x.CategoriaId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<RunPost>
        {
            private readonly IProductoRepository _productoRepository;
            public Handler(IProductoRepository productoRepository)
            {
                this._productoRepository = productoRepository;
            }

            public async Task<Unit> Handle(RunPost request, CancellationToken cancellationToken)
            {
                var productoModel = new ProductoModel
                {
                    NombreProducto = request.NombreProducto,
                    Descripcion = request.Descripcion,
                    Stock = request.Stock ?? 0,
                    PrecioVenta = request.PrecioVenta,
                    CategoriaId = request.CategoriaId
                };

                var result = await _productoRepository.Post(productoModel);

                if (result > 0)
                {
                    return Unit.Value;
                }
                
                throw new Exception("No se pudo agregar el Producto");
            }
        }

    }
}