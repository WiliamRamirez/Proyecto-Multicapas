using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using MediatR;
using Persistence.DapperConnection.Proveedores;

namespace Application.Proveedor
{
    public class Delete
    {
        public class RunDelete : IRequest
        {
            public Guid ProveedorId { get; set; }
        }

        public class Handler : IRequestHandler<RunDelete>
        {
            private readonly IProveedorRepository _proveedorRepository;
            public Handler(IProveedorRepository proveedorRepository)
            {
                this._proveedorRepository = proveedorRepository;

            }

            public async Task<Unit> Handle(RunDelete request, CancellationToken cancellationToken)
            {
                var proveedor = await _proveedorRepository.Get(request.ProveedorId); ;
                
                if (proveedor == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No se encontro el proveedor" });
                }

                var result = await _proveedorRepository.Delete(request.ProveedorId);

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo Eliminar el Proveedor");
            }
        }
    }
}