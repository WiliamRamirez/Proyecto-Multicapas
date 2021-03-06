using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using MediatR;
using Persistence.DapperConnection.Combos;

namespace Application.Combos
{
    public class Put
    {
        public class RunPut : IRequest
        {
            public Guid ComboId { get; set; }
            public string NombreCombo { get; set; }
            public int Cantidad { get; set; }
            public Decimal PrecioCombo { get; set; }
            public Guid ProductoId { get; set; }
        }

        public class Handler : IRequestHandler<RunPut>
        {
            private readonly IComboRepository _comboRepository;
            public Handler(IComboRepository comboRepository)
            {
                this._comboRepository = comboRepository;

            }
            public async Task<Unit> Handle(RunPut request, CancellationToken cancellationToken)
            {
                var combo = await _comboRepository.GetId(request.ComboId);

                if (combo == null)
                {
                    throw new ManejadorError(HttpStatusCode.NotFound, new { mensaje = "No se encontro el combo"});
                }

                var comboModel = new ComboModel
                {
                    ComboId = request.ComboId,
                    NombreCombo = request.NombreCombo,
                    Cantidad = request.Cantidad,
                    PrecioCombo = request.PrecioCombo,
                    ProductoId = request.ProductoId
                };

                var result = await _comboRepository.Put(comboModel);

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo actualizar el combo");

            }
        }
    }
}