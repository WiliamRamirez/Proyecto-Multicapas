using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using MediatR;
using Persistence.DapperConnection.Proveedores;

namespace Application.Proveedor
{
    public class Put
    {
        public class RunPut : IRequest
        {
            public Guid ProveedorId { get; set; }
            public string NombreProveedor { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
        }

        public class Handler : IRequestHandler<RunPut>
        {
            private readonly IProveedorRepository _proveedorRepository;
            public Handler(IProveedorRepository proveedorRepository)
            {
                this._proveedorRepository = proveedorRepository;

            }

            public async Task<Unit> Handle(RunPut request, CancellationToken cancellationToken)
            {
                var proveedor = await _proveedorRepository.Get(request.ProveedorId); ;

                if (proveedor == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No se encontro el proveedor" });
                }
                
                var proveedorModel = new ProveedorModel
                {
                    ProveedorId = request.ProveedorId,
                    NombreProveedor = request.NombreProveedor ?? proveedor.NombreProveedor,
                    Telefono = request.Telefono ?? proveedor.Telefono,
                    Direccion = request.Direccion ?? proveedor.Direccion
                };

                var result = await _proveedorRepository.Put(proveedorModel);

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo actualizar el proveedor");
            }
        }
    }
}