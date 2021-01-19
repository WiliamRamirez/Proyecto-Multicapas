using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistence.DapperConnection.Combos;

namespace Application.Combos
{
    public class Post
    {
        public class RunPost : IRequest
        {
            public string NombreCombo { get; set; }
            public int Cantidad { get; set; }
            public Decimal PrecioCombo { get; set; }
            public Guid ProductoId { get; set; }
        }
        public class RunPostValidation : AbstractValidator<RunPost>
        {
            public RunPostValidation()
            {
                RuleFor(x => x.NombreCombo).NotEmpty();
                RuleFor(x => x.Cantidad).NotEmpty();
                RuleFor(x => x.PrecioCombo).NotEmpty();
                RuleFor(x => x.ProductoId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<RunPost>
        {
            private readonly IComboRepository _comboRepository;
            public Handler(IComboRepository comboRepository)
            {
                this._comboRepository = comboRepository;
            }

            public async Task<Unit> Handle(RunPost request, CancellationToken cancellationToken)
            {
                var comboModel = new ComboModel
                {
                    NombreCombo = request.NombreCombo,
                    Cantidad = request.Cantidad,
                    PrecioCombo = request.PrecioCombo,
                    ProductoId = request.ProductoId
                };
                var result = await _comboRepository.Post(comboModel);

                if (result > 0)
                {
                    return Unit.Value;
                }
                
                throw new Exception("No se pudo agregar el combo");
            }
        }
    }
}