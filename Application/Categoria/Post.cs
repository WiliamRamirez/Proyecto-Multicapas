using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistence.DapperConnection.Categorias;

namespace Application.Categoria
{
    public class Post
    {
        public class RunPost : IRequest
        {
            public string NombreCategoria { get; set; }
            public string Descripcion { get; set; }
        }

        public class RunPostValidation : AbstractValidator<RunPost>
        {
            public RunPostValidation()
            {
                RuleFor(x => x.NombreCategoria).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<RunPost>
        {
            private readonly ICategoriaRepository _categoriaRepository;
            public Handler(ICategoriaRepository categoriaRepository)
            {
                this._categoriaRepository = categoriaRepository;

            }

            public async Task<Unit> Handle(RunPost request, CancellationToken cancellationToken)
            {
                var categoriaModel = new CategoriaModel
                {
                    NombreCategoria = request.NombreCategoria,
                    Descripcion = request.Descripcion
                };

                var resultado = await _categoriaRepository.Post(categoriaModel);
                
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                
                throw new Exception("No se pudo insertar la Categoria");
            }
        }
    }
}