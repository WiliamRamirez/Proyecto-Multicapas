using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Persistence.DapperConnection.DetallesCompras
{
    public class DetalleCompraRepository : IDetalleCompraRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public DetalleCompraRepository(IFactoryConnection factoryConnection)
        {
            this._factoryConnection = factoryConnection;

        }
        public Task<int> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DetalleCompraModel>> Get(Guid Id)
        {
            IEnumerable<DetalleCompraModel> listDetalleCompra = null;

            var storeProcedure = "usp_Get_DetalleCompra";

            try
            {
                var connection = _factoryConnection.GetConnection();
                listDetalleCompra = await connection.QueryAsync<DetalleCompraModel>(storeProcedure, new
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

            return listDetalleCompra;
        }

        public Task<DetalleCompraModel> GetId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Post(DetalleCompraModel parameters)
        {
            var storeProcedure = "usp_Post_DetalleCompra";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    DetalleCompraId = Guid.NewGuid(),
                    Cantidad = parameters.Cantidad,
                    PrecioUnitario = parameters.PrecioUnitario,
                    SubTotal = parameters.SubTotal,
                    CompraId = parameters.CompraId,
                    ProductoId = parameters.ProductoId,
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

        public Task<int> Put(DetalleCompraModel parameters)
        {
            throw new NotImplementedException();
        }
    }
}