using System;

namespace Persistence.DapperConnection.DetallesCompras
{
    public class DetalleCompraModel
    {
        public Guid DetalleCompraId { get; set; }
        public Decimal Cantidad { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public Decimal SubTotal { get; set; }
        public Guid CompraId { get; set; }
        public Guid ProductoId { get; set; }
        public byte Estado { get; set; }
        public string NombreProducto { get; set; }
    }
}