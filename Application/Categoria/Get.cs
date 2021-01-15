using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence.DapperConnection.Categorias;

namespace Application.Categoria
{
    public class Get
    {
        public class RunGet : IRequest<List<CategoriaModel>>
        {

        }

        public class Handler : IRequestHandler<RunGet, List<CategoriaModel>>
        {
            private readonly ICategoriaRepository _categoriaRepository;
            public Handler(ICategoriaRepository categoriaRepository)
            {
                this._categoriaRepository = categoriaRepository;

            }

            public async Task<List<CategoriaModel>> Handle(RunGet request, CancellationToken cancellationToken)
            {
                var resultado = await _categoriaRepository.Get();

                return resultado.ToList();
            }
        }
    }
}