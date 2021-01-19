using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Compra
    {
        public Guid CompraId { get; set; }
        public DateTime FechaCompra { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Correlativo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Igv { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Descuento { get; set; }
        public Guid ProveedorId { get; set; }
        public byte Estado { get; set; }

        // Link a la Tabla Proveedor
        public Proveedor Proveedor { get; set; }
        public ICollection<DetalleCompra> DetalleCompras { get; set; }

    }
}