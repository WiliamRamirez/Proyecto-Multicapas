using System;

namespace Persistence.DapperConnection.Compras
{
    public class CompraModel
    {
        public Guid CompraId { get; set; }
        public DateTime FechaCompra { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public Decimal Correlativo { get; set; }
        public Decimal Igv { get; set; }
        public Decimal Descuento { get; set; }
        public Guid ProveedorId { get; set; }
        public byte Estado { get; set; }
        public string NombreProveedor { get; set; }
    }
}