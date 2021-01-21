using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Security
{
    public class GetUser
    {
        public class RunGetUser : IRequest<List<UsuarioDTO>>
        {

        }

        public class Handler : IRequestHandler<RunGetUser, List<UsuarioDTO>>
        {
            private readonly SistemaDbContext _context;
            private readonly IMapper _mapper;

            public Handler(SistemaDbContext context, IMapper mapper)
            {
                this._mapper = mapper;
                this._context = context;
            }

            public async Task<List<UsuarioDTO>> Handle(RunGetUser request, CancellationToken cancellationToken)
            {
                var usuarios = await _context.Users.Where(x => x.Estado == 1 && x.isAdmin != 1  ).ToListAsync();
                var usuarioDTO = _mapper.Map<List<UsuarioDTO>>(usuarios);

                return usuarioDTO;
            }
        }
    }
}