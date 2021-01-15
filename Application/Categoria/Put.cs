using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using MediatR;
using Persistence.DapperConnection.Categorias;

namespace Application.Categoria
{
    public class Put
    {
        public class RunPut : IRequest
        {
            public Guid CategoriaId { get; set; }
            public string NombreCategoria { get; set; }
            public string Descripcion { get; set; }
        }

        public class Handler : IRequestHandler<RunPut>
        {
            private readonly ICategoriaRepository _categoriaRepository;
            public Handler(ICategoriaRepository categoriaRepository)
            {
                this._categoriaRepository = categoriaRepository;

            }

            public async Task<Unit> Handle(RunPut request, CancellationToken cancellationToken)
            {
                var categoria = await _categoriaRepository.Get(request.CategoriaId);

                if (categoria == null)
                {
                    throw new ManejadorError(HttpStatusCode.NoContent, new { mensaje = "La categoria no existe" });
                }

                var categoriaModel = new CategoriaModel
                {
                    CategoriaId = request.CategoriaId,
                    NombreCategoria = request.NombreCategoria ?? categoria.NombreCategoria,
                    Descripcion = request.Descripcion ?? categoria.Descripcion
                };

                var result = await _categoriaRepository.Put(categoriaModel);

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo actualizar la categoria");
            }
        }
    }
}