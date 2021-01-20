using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Persistence.DapperConnection.Compras
{
    public class CompraRepository : ICompraRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public CompraRepository(IFactoryConnection factoryConnection)
        {
            this._factoryConnection = factoryConnection;

        }
        
        public Task<int> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompraModel>> Get()
        {
            IEnumerable<CompraModel> listCompras = null;

            var storeProcedure = "usp_Get_Compra";

            try
            {
                var connection = _factoryConnection.GetConnection();
                listCompras = await connection.QueryAsync<CompraModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);
            }
            catch (System.Exception e)
            {

                throw new Exception("Error en la consulta en la Base de datos", e);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return listCompras;
        }

        public async Task<CompraModel> Get(Guid Id)
        {
            CompraModel compra = null;

            var storeProcedure = "usp_GetId_Compra";

            try
            {
                var connection = _factoryConnection.GetConnection();
                compra = await connection.QueryFirstOrDefaultAsync<CompraModel>(storeProcedure, new
                {
                    CompraId = Id
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

            return compra;
        }

        public async Task<int> Post(CompraModel parameters)
        {
            var storeProcedure = "usp_Post_Compra";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    CompraId = parameters.CompraId,
                    FechaCompra = parameters.FechaCompra,
                    TipoComprobante = parameters.TipoComprobante,
                    Serie = parameters.Serie,
                    Correlativo = parameters.Correlativo,
                    Igv = parameters.Igv,
                    Descuento = parameters.Descuento,
                    ProveedorId = parameters.ProveedorId,          

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

        public Task<int> Put(CompraModel parameters)
        {
            throw new NotImplementedException();
        }
    }
}