using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class DetalleVenta
    {
        public Guid DetalleVentaId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Descuento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Cantidad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal SubTotal { get; set; }

        public Guid ProductoId { get; set; }
        public Guid VentaId { get; set; }

        public Producto Producto { get; set; }
        public Venta Venta { get; set; }


    }
}