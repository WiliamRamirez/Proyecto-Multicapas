using System.Reflection.Metadata;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTOs;
using Application.ExceptionHandler;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;

namespace Application.Security
{
    public class UpdateUser
    {
        public class RunUpdateUser : IRequest<UserDTO>
        {
            public Guid Id { get; set; }
            public string NombreCompleto { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string UserName { get; set; }
        }

        public class RunUpdateUserValidation : AbstractValidator<RunUpdateUser>
        {
            public RunUpdateUserValidation()
            {
                RuleFor(x => x.NombreCompleto).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<RunUpdateUser, UserDTO>
        {
            private readonly SistemaDbContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IPasswordHasher<Usuario> _passwordHasher;

            public Handler(SistemaDbContext context, UserManager<Usuario> userManager, IJwtGenerator jwtGenerator, IPasswordHasher<Usuario> passwordHasher)
            {
                this._context = context;
                this._userManager = userManager;
                this._jwtGenerator = jwtGenerator;
                this._passwordHasher = passwordHasher;
            }

            public async Task<UserDTO> Handle(RunUpdateUser request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.Id.ToString());

                if (user == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No existe el usuario" });
                }

                var existsUsername = await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync();

                var existsEmail = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();

                if (existsUsername)
                {
                    throw new ManejadorError(HttpStatusCode.InternalServerError, new { mensaje = "Este UserName Pertenece a otro usuario" });
                }
                else if (existsEmail)
                {
                    throw new ManejadorError(HttpStatusCode.InternalServerError, new { mensaje = "Este Email Pertenece a otro usuario" });
                }

                // Actualizando usuario

                user.UserName = request.UserName;
                user.Email = request.Email;
                user.NombreCompleto = request.NombreCompleto;
                user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

                //

                var resultUpdate = await _userManager.UpdateAsync(user);

                // Listar Roles
                var resultRoles = await _userManager.GetRolesAsync(user);
                var listRoles = new List<string>(resultRoles);

                if (resultUpdate.Succeeded)
                {
                    return new UserDTO
                    {
                        Id = new Guid(user.Id),
                        NombreCompleto = user.NombreCompleto,
                        Token = _jwtGenerator.CreateToken(user, listRoles),
                        Username = user.UserName,
                        Email = user.Email,
                    };
                }

                throw new Exception("No se pudo actualizar el usuario");

            }
        }




    }
}