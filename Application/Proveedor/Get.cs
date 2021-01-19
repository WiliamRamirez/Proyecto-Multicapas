using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence.DapperConnection.Proveedores;

namespace Application.Proveedor
{
    public class Get
    {
        public class RunGet : IRequest<List<ProveedorModel>>
        {

        }

        public class Handler : IRequestHandler<RunGet,List<ProveedorModel>>
        {
            private readonly IProveedorRepository _proveedorRepository;
            public Handler(IProveedorRepository proveedorRepository)
            {
                this._proveedorRepository = proveedorRepository;

            }

            public async Task<List<ProveedorModel>> Handle(RunGet request, CancellationToken cancellationToken)
            {
                var result = await _proveedorRepository.Get();
                return result.ToList();
            }
        }
    }
}