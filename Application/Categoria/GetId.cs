using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence.DapperConnection.Categorias;
using Application.ExceptionHandler;

namespace Application.Categoria
{
    public class GetId
    {
        public class RunGetId : IRequest<CategoriaModel>
        {
            public Guid CategoriaId { get; set; }
        }

        public class Handler : IRequestHandler<RunGetId, CategoriaModel>
        {
            private readonly ICategoriaRepository _categoriaRepository;
            public Handler(ICategoriaRepository categoriaRepository)
            {
                this._categoriaRepository = categoriaRepository;
            }
            
            public async Task<CategoriaModel> Handle(RunGetId request, CancellationToken cancellationToken)
            {
                var categoria = await _categoriaRepository.Get(request.CategoriaId);

                if (categoria == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "La categoria no existe" });
                }

                return categoria;
            }
        }
    }
}