using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Persistence.DapperConnection.Proveedores
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public ProveedorRepository(IFactoryConnection factoryConnection)
        {
            this._factoryConnection = factoryConnection;

        }

        public async Task<int> Delete(Guid Id)
        {
            var storeProcedure = "usp_Delete_Proveedor";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    ProveedorId = Id
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

        public async Task<IEnumerable<ProveedorModel>> Get()
        {
            IEnumerable<ProveedorModel> listProveedores = null;

            var storeProcedure = "usp_Get_Proveedor";

            try
            {
                var connection = _factoryConnection.GetConnection();
                listProveedores = await connection.QueryAsync<ProveedorModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);
            }
            catch (System.Exception e)
            {

                throw new Exception("Error en la consulta en la Base de datos", e);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return listProveedores;
        }

        public async Task<ProveedorModel> Get(Guid Id)
        {
            ProveedorModel proveedor = null;

            var storeProcedure = "usp_GetId_Proveedor";

            try
            {
                var connection = _factoryConnection.GetConnection();
                proveedor = await connection.QueryFirstOrDefaultAsync<ProveedorModel>(storeProcedure, new
                {
                    ProveedorId = Id
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

            return proveedor;
        }

        public async Task<int> Post(ProveedorModel parameters)
        {
            var storeProcedure = "usp_Post_Proveedor";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    ProveedorId = Guid.NewGuid(),
                    NombreProveedor = parameters.NombreProveedor,
                    Telefono = parameters.Telefono,
                    Direccion = parameters.Direccion,
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

        public async Task<int> Put(ProveedorModel parameters)
        {
            var storeProcedure = "usp_Put_Proveedor";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    ProveedorId = parameters.ProveedorId,
                    NombreProveedor = parameters.NombreProveedor,
                    Telefono = parameters.Telefono,
                    Direccion = parameters.Direccion,
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