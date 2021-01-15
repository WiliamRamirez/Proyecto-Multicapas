using System.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace Persistence.DapperConnection.Categorias
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public CategoriaRepository(IFactoryConnection factoryConnection)
        {
            this._factoryConnection = factoryConnection;
        }
        public async Task<int> Delete(Guid Id)
        {
            var storeProcedure = "usp_Delete_Categoria";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    CategoriaId = Id
                }
                , commandType: CommandType.StoredProcedure);

                _factoryConnection.CloseConnection();

                return resultado;

            }
            catch (System.Exception e)
            {

                throw new Exception("Error en la base de datos", e);
            }
        }

        public async Task<IEnumerable<CategoriaModel>> Get()
        {
            IEnumerable<CategoriaModel> listCategorias = null;

            var storeProcedure = "usp_Get_Categoria";

            try
            {
                var connection = _factoryConnection.GetConnection();
                listCategorias = await connection.QueryAsync<CategoriaModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);
            }
            catch (System.Exception e)
            {

                throw new Exception("Error en la consulta en la Base de datos", e);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return listCategorias;
        }

        public async Task<CategoriaModel> Get(Guid Id)
        {
            CategoriaModel categoria = null;

            var storeProcedure = "usp_GetId_Categoria";

            try
            {
                var connection = _factoryConnection.GetConnection();
                categoria = await connection.QueryFirstOrDefaultAsync<CategoriaModel>(storeProcedure, new
                {
                    CategoriaId = Id
                }, commandType: CommandType.StoredProcedure);
            }
            catch (System.Exception e)
            {

                throw new Exception("Error en la consulta en la Base de datos", e);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return categoria;
        }

        public async Task<int> Post(CategoriaModel parameters)
        {
            var storeProcedure = "usp_Post_Categoria";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    CategoriaId = Guid.NewGuid(),
                    NombreCategoria = parameters.NombreCategoria,
                    Descripcion = parameters.Descripcion
                }
                , commandType: CommandType.StoredProcedure);

                _factoryConnection.CloseConnection();

                return resultado;

            }
            catch (System.Exception e) 
            {

                throw new Exception("Error en la base de datos", e);
            }
        }

        public async Task<int> Put(CategoriaModel parameters)
        {
            var storeProcedure = "usp_Put_Categoria";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    CategoriaId = parameters.CategoriaId,
                    NombreCategoria = parameters.NombreCategoria,
                    Descripcion = parameters.Descripcion
                }
                , commandType: CommandType.StoredProcedure);

                _factoryConnection.CloseConnection();

                return resultado;

            }
            catch (System.Exception e)
            {

                throw new Exception("Error en la base de datos", e);
            }
        }
    }
}