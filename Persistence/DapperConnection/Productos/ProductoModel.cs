using System;

namespace Persistence.DapperConnection.Productos
{
    public class ProductoModel
    {
        public Guid ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public Decimal PrecioVenta { get; set; }
        public byte Estado { get; set; }
        public Guid CategoriaId { get; set; }
        public string NombreCategoria { get; set; }

    }
}