using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using MediatR;
using Persistence.DapperConnection.Proveedores;

namespace Application.Proveedor
{
    public class GetId
    {
        public class RunGetId : IRequest<ProveedorModel>
        {
            public Guid ProveedorId { get; set; }
        }

        public class Handler : IRequestHandler<RunGetId,ProveedorModel>
        {
            private readonly IProveedorRepository _proveedorRepository;
            public Handler(IProveedorRepository proveedorRepository)
            {
                this._proveedorRepository = proveedorRepository;

            }

            public async Task<ProveedorModel> Handle(RunGetId request, CancellationToken cancellationToken)
            {
                var proveedor = await _proveedorRepository.Get(request.ProveedorId); ;

                if (proveedor == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No se encontro el proveedor" });
                }

                return proveedor;
            }
        }
    }
}