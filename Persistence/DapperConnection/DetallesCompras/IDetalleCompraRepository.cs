using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.DapperConnection.DetallesCompras
{
    public interface IDetalleCompraRepository
    {
        Task<IEnumerable<DetalleCompraModel>> Get(Guid Id);
        Task<DetalleCompraModel> GetId(Guid Id);
        Task<int> Post(DetalleCompraModel parameters);
        Task<int> Put(DetalleCompraModel parameters);
        Task<int> Delete(Guid Id);
    }
}