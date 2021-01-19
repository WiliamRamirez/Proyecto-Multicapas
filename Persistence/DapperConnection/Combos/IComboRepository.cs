using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.DapperConnection.Combos
{
    public interface IComboRepository
    {
        Task<IEnumerable<ComboModel>> Get();
        Task<IEnumerable<ComboModel>> Get(Guid Id);
        Task<ComboModel> GetId(Guid Id);
        Task<int> Post(ComboModel parameters);
        Task<int> Put(ComboModel parameters);
        Task<int> Delete(Guid Id);
    }
}