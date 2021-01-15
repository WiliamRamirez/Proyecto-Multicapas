using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Persistence.DapperConnection.Categorias
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<CategoriaModel>> Get();
        Task<CategoriaModel> Get(Guid Id);

        Task<int> Post(CategoriaModel parameters);
        Task<int> Put(CategoriaModel parameters);
        Task<int> Delete(Guid Id);


    }
}