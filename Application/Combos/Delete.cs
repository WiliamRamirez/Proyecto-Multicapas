using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using MediatR;
using Persistence.DapperConnection.Combos;

namespace Application.Combos
{
    public class Delete
    {
        public class RunDelete : IRequest
        {
            public Guid ComboId { get; set; }
        }

        public class Handler : IRequestHandler<RunDelete>
        {
            private readonly IComboRepository _comboRepository;
            public Handler(IComboRepository comboRepository)
            {
                this._comboRepository = comboRepository;

            }
            public async Task<Unit> Handle(RunDelete request, CancellationToken cancellationToken)
            {
                var combo = await _comboRepository.GetId(request.ComboId);

                if (combo == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No se encontro el combo" });
                }

                var result = await _comboRepository.Delete(request.ComboId);

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo Eliminar el combo");
            }
        }
    }
}