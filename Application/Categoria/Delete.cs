using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using MediatR;
using Persistence.DapperConnection.Categorias;

namespace Application.Categoria
{
    public class Delete
    {
        public class RunDelete : IRequest
        {
            public Guid CategoriaId { get; set; }
        }

        public class Handler : IRequestHandler<RunDelete>
        {
            private readonly ICategoriaRepository _categoriaRepository;
            public Handler(ICategoriaRepository categoriaRepository)
            {
                this._categoriaRepository = categoriaRepository;

            }
            public async Task<Unit> Handle(RunDelete request, CancellationToken cancellationToken)
            {
                var categoria = await _categoriaRepository.Get(request.CategoriaId);

                if (categoria == null)
                {
                    throw new ManejadorError(HttpStatusCode.NoContent, new { mensaje = "La categoria no existe" });
                }

                var result = await _categoriaRepository.Delete(request.CategoriaId);

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo Eliminar la Categoria");
            }
        }

    }
}