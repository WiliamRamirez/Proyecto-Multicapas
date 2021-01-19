using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.DapperConnection.Productos
{
    public interface IProductoRepository
    {
        Task<IEnumerable<ProductoModel>> Get();
        Task<ProductoModel> Get(Guid Id);
        Task<int> Post(ProductoModel parameters);
        Task<int> Put(ProductoModel parameters);
        Task<int> Delete(Guid Id);
    }
}