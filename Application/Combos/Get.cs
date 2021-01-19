using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence.DapperConnection.Combos;

namespace Application.Combos
{
    public class Get
    {
        public class RunGet : IRequest<List<ComboDTO>>
        {

        }

        public class Handler : IRequestHandler<RunGet, List<ComboDTO>>
        {
            private readonly IComboRepository _comboRepository;
            private readonly IMapper _mapper;
            public Handler(IComboRepository comboRepository, IMapper mapper)
            {
                this._mapper = mapper;
                this._comboRepository = comboRepository;
            }

            public async Task<List<ComboDTO>> Handle(RunGet request, CancellationToken cancellationToken)
            {
                var result = await _comboRepository.Get();
                var listComboDTO = _mapper.Map<List<ComboDTO>>(result.ToList());
                
                return listComboDTO;
            }
        }
    }
}