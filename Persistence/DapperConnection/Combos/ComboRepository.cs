using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Persistence.DapperConnection.Combos
{
    public class ComboRepository : IComboRepository
    {
        private readonly IFactoryConnection _factoryConnection;

        public ComboRepository(IFactoryConnection factoryConnection)
        {
            this._factoryConnection = factoryConnection;
        }
        
        public async Task<int> Delete(Guid Id)
        {
            var storeProcedure = "usp_Delete_Combo";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    ComboId = Id
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

        public async Task<IEnumerable<ComboModel>> Get(Guid Id)
        {
            IEnumerable<ComboModel> listCombos = null;

            var storeProcedure = "usp_Get_Combo";

            try
            {
                var connection = _factoryConnection.GetConnection();
                listCombos = await connection.QueryAsync<ComboModel>(storeProcedure, new
                {
                    ProductoId = Id
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

            return listCombos;
        }

        public async Task<IEnumerable<ComboModel>> Get()
        {
            IEnumerable<ComboModel> listCombos = null;

            var storeProcedure = "usp_Get_ComboList";

            try
            {
                var connection = _factoryConnection.GetConnection();
                listCombos = await connection.QueryAsync<ComboModel>(storeProcedure, null , commandType: CommandType.StoredProcedure);
            }
            catch (System.Exception e)
            {

                throw new Exception("Error en la consulta en la Base de datos", e);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return listCombos;
        }

        public async Task<ComboModel> GetId(Guid Id)
        {
            ComboModel combo = null;

            var storeProcedure = "usp_GetId_Combo";

            try
            {
                var connection = _factoryConnection.GetConnection();
                combo = await connection.QueryFirstOrDefaultAsync<ComboModel>(storeProcedure, new
                {
                    ComboId = Id
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

            return combo;
        }

        public async Task<int> Post(ComboModel parameters)
        {
            var storeProcedure = "usp_Post_Combo";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    ComboId = Guid.NewGuid(),
                    NombreCombo = parameters.NombreCombo,
                    Cantidad = parameters.Cantidad,
                    PrecioCombo = parameters.PrecioCombo,
                    ProductoId = parameters.ProductoId
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

        public async Task<int> Put(ComboModel parameters)
        {
            var storeProcedure = "usp_Put_Combo";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    ComboId = parameters.ComboId,
                    NombreCombo = parameters.NombreCombo,
                    Cantidad = parameters.Cantidad,
                    PrecioCombo = parameters.PrecioCombo,
                    ProductoId = parameters.ProductoId
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