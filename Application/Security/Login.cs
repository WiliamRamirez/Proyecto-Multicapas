using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTOs;
using Application.ExceptionHandler;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;
using FluentValidation;
using System;

namespace Application.Security
{
    public class Login
    {
        public class RunLogin : IRequest<UserDTO>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class RunLoginValidation : AbstractValidator<RunLogin>
        {
            public RunLoginValidation()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<RunLogin, UserDTO>
        {
            private readonly SistemaDbContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly SignInManager<Usuario> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(SistemaDbContext context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IJwtGenerator jwtGenerator)
            {
                this._context = context;
                this._userManager = userManager;
                this._signInManager = signInManager;
                this._jwtGenerator = jwtGenerator;
            }

            public async Task<UserDTO> Handle(RunLogin request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                {
                    throw new ManejadorError(HttpStatusCode.Unauthorized);
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                var resultRoles = await _userManager.GetRolesAsync(user);

                var listRoles = new List<string>(resultRoles);

                if (result.Succeeded)
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

                throw new ManejadorError(HttpStatusCode.Unauthorized);

            }
        }
    }
}