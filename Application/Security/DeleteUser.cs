using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application.Security
{
    public class DeleteUser
    {
        public class RunDeleteUser : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<RunDeleteUser>
        {
            private readonly SistemaDbContext _context;
            private readonly UserManager<Usuario> _userManager;

            public Handler(SistemaDbContext context, UserManager<Usuario> userManager)
            {
                this._userManager = userManager;
                this._context = context;
            }

            public async Task<Unit> Handle(RunDeleteUser request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.Id.ToString());

                if (user == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No existe el usuario" });
                }

                //Cambiar Estado usuario
                user.Estado = 0;

                var resultUpdate = await _userManager.UpdateAsync(user);

                if (resultUpdate.Succeeded)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el usuario");
            }
        }


    }
}