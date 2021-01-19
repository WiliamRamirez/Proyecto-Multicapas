using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.DapperConnection.Proveedores
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<ProveedorModel>> Get();
        Task<ProveedorModel> Get(Guid Id);
        Task<int> Post(ProveedorModel parameters);
        Task<int> Put(ProveedorModel parameters);
        Task<int> Delete(Guid Id);
    }
}