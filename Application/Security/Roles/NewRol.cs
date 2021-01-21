using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Security.Roles
{
    public class NewRol
    {
        public class RunNewRol : IRequest
        {
            public string NombreRol { get; set; }
        }

        public class RunNewRolEjecute : AbstractValidator<RunNewRol>
        {
            public RunNewRolEjecute()
            {
                RuleFor(x => x.NombreRol).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<RunNewRol>
        {
            private readonly RoleManager<IdentityRole> _roleManager;

            public Handler(RoleManager<IdentityRole> roleManager)
            {
                this._roleManager = roleManager;
            }
            
            public async Task<Unit> Handle(RunNewRol request, CancellationToken cancellationToken)
            {
                var rol = await _roleManager.FindByNameAsync(request.NombreRol);

                if (rol != null)
                {
                    throw new ManejadorError(HttpStatusCode.BadRequest, new { mensaje = "Ya existe el rol" });
                }

                var result = await _roleManager.CreateAsync(new IdentityRole(request.NombreRol));

                if (result.Succeeded)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo crear el rol");
            }
        }
    }
}