using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Combo
    {
        public Guid ComboId { get; set; }
        public string NombreCombo { get; set; }
        public int Cantidad { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public Decimal PrecioCombo { get; set; }
        public byte Estado { get; set; }
        public Guid ProductoId { get; set; }

        public Producto Producto { get; set; }
    }
}