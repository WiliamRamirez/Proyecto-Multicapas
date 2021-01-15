using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Venta
    {
        public Guid VentaId { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Correlativo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Igv { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Descuento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal TotalImporte { get; set; }
        public Guid ClienteId { get; set; }

        public Cliente Cliente { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
        
    }
}