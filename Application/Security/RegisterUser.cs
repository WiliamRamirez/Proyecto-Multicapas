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

namespace Application.Security
{
    public class RegisterUser
    {
        public class RunRegisterUser : IRequest<UserDTO>
        {
            public string NombreCompleto { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
        }

        public class RunRegisterUserValidation : AbstractValidator<RunRegisterUser>
        {
            public RunRegisterUserValidation()
            {
                RuleFor(x => x.NombreCompleto).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<RunRegisterUser, UserDTO>
        {
            private readonly SistemaDbContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(SistemaDbContext context, UserManager<Usuario> userManager, IJwtGenerator jwtGenerator)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<UserDTO> Handle(RunRegisterUser request, CancellationToken cancellationToken)
            {
                var existsEmail = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();

                if (existsEmail)
                {
                    throw new ManejadorError(HttpStatusCode.BadRequest, new
                    {
                        mensaje = "El usuario ingresado ya existe"
                    });
                }

                var existsUserName = await _context.Users.Where(x => x.UserName == request.Username).AnyAsync();

                if (existsUserName)
                {
                    throw new ManejadorError(HttpStatusCode.BadRequest, new
                    {
                        mensaje = "El username ingresado ya existe"
                    });
                }

                var user = new Usuario
                {
                    NombreCompleto = request.NombreCompleto,
                    Email = request.Email,
                    UserName = request.Username,
                    Estado = 1,
                    isAdmin = 0
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    return new UserDTO
                    {
                        Id = new Guid(user.Id),
                        NombreCompleto = user.NombreCompleto,
                        Token = _jwtGenerator.CreateToken(user, null),
                        Email = user.Email,
                        Username = user.UserName
                    };
                }

                throw new Exception("No se pudo agregar al nuevo usuario");

            }
        }
    }
}