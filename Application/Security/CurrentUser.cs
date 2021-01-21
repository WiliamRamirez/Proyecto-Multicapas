using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application.Security
{
    public class CurrentUser
    {
        public class RunCurrentUser : IRequest<UserDTO>
        {

        }

        public class Handler : IRequestHandler<RunCurrentUser, UserDTO>
        {
            private readonly SistemaDbContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerator _jwtGenerador;
            private readonly IUserSession _userSession;
            public Handler(SistemaDbContext context, UserManager<Usuario> userManager, IJwtGenerator jwtGenerador, IUserSession userSession)
            {
                this._context = context;
                this._userManager = userManager;
                this._jwtGenerador = jwtGenerador;
                this._userSession = userSession;
            }

            public async Task<UserDTO> Handle(RunCurrentUser request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(_userSession.GetUserSession());

                var resultRoles = await _userManager.GetRolesAsync(user);

                var listRoles = new List<string>(resultRoles);

                return new UserDTO
                {
                    Id = new Guid(user.Id),
                    NombreCompleto = user.NombreCompleto,
                    Username = user.UserName,
                    Token = _jwtGenerador.CreateToken(user, listRoles),
                    Email = user.Email
                };
            }
        }
    }
}