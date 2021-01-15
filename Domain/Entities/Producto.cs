using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Producto
    {
        public Guid ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public Decimal PrecioVenta { get; set; }
        public int Estado { get; set; }
        public Guid CategoriaId { get; set; }

        public ICollection<Combo> Combos { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<DetalleCompra> DetalleCompras { get; set; }

    }
}