using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistence.DapperConnection.Proveedores;

namespace Application.Proveedor
{
    public class Post
    {
        public class RunPost : IRequest
        {
            public string NombreProveedor { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
        }
        public class RunPostValidation : AbstractValidator<RunPost>
        {
            public RunPostValidation()
            {
                RuleFor(x => x.NombreProveedor).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
                RuleFor(x => x.Direccion).NotEmpty();
            }
        }
        
        public class Handler : IRequestHandler<RunPost>
        {
            private readonly IProveedorRepository _proveedorRepository;
            public Handler(IProveedorRepository proveedorRepository)
            {
                this._proveedorRepository = proveedorRepository;

            }

            public async Task<Unit> Handle(RunPost request, CancellationToken cancellationToken)
            {
                var proveedorModel = new ProveedorModel
                {
                    NombreProveedor = request.NombreProveedor,
                    Telefono = request.Telefono,
                    Direccion = request.Direccion
                };

                var result = await _proveedorRepository.Post(proveedorModel);

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo agregar ek Instructor");
            }
        }
    }
}