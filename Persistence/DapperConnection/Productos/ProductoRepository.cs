using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Persistence.DapperConnection.Productos
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public ProductoRepository(IFactoryConnection factoryConnection)
        {
            this._factoryConnection = factoryConnection;

        }

        public async Task<int> Delete(Guid Id)
        {
            var storeProcedure = "usp_Delete_Producto";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    ProductoId = Id
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

        public async Task<IEnumerable<ProductoModel>> Get()
        {
            IEnumerable<ProductoModel> listProductos = null;

            var storeProcedure = "usp_Get_Producto";

            try
            {
                var connection = _factoryConnection.GetConnection();
                listProductos = await connection.QueryAsync<ProductoModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);
            }
            catch (System.Exception e)
            {

                throw new Exception("Error en la consulta en la Base de datos", e);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return listProductos;
        }

        public async Task<ProductoModel> Get(Guid Id)
        {
            ProductoModel producto = null;

            var storeProcedure = "usp_GetId_Producto";

            try
            {
                var connection = _factoryConnection.GetConnection();
                producto = await connection.QueryFirstOrDefaultAsync<ProductoModel>(storeProcedure, new
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

            return producto;
        }

        public async Task<int> Post(ProductoModel parameters)
        {
            var storeProcedure = "usp_Post_Producto";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    ProductoId = Guid.NewGuid(),
                    NombreProducto = parameters.NombreProducto,
                    Descripcion = parameters.Descripcion,
                    Stock = parameters.Stock,
                    PrecioVenta = parameters.PrecioVenta,
                    CategoriaId = parameters.CategoriaId

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

        public async Task<int> Put(ProductoModel parameters)
        {
            var storeProcedure = "usp_Put_Producto";

            try
            {
                var connection = _factoryConnection.GetConnection();
                var resultado = await connection.ExecuteAsync(storeProcedure, new
                {
                    ProductoId = parameters.ProductoId,
                    NombreProducto = parameters.NombreProducto,
                    Descripcion = parameters.Descripcion,
                    Stock = parameters.Stock,
                    PrecioVenta = parameters.PrecioVenta,
                    CategoriaId = parameters.CategoriaId
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