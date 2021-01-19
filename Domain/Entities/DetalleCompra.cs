using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class DetalleCompra
    {
        public Guid DetalleCompraId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Cantidad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal SubTotal { get; set; }

        public Guid CompraId { get; set; }
        public Guid ProductoId { get; set; }
        public byte Estado { get; set; }

        //Link a la Tabla Compra y Producto
        public Compra Compra { get; set; }
        public Producto Producto { get; set; }
    }
}