using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.DapperConnection.Compras
{
    public interface ICompraRepository
    {
        Task<IEnumerable<CompraModel>> Get();
        Task<CompraModel> Get(Guid Id);
        Task<int> Post(CompraModel parameters);
        Task<int> Put(CompraModel parameters);
        Task<int> Delete(Guid Id);
    }
}