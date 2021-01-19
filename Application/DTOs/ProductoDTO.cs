using System.Collections.Generic;
using System;

namespace Application.DTOs
{
    public class ProductoDTO
    {
        public Guid ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public Decimal PrecioVenta { get; set; }
        public byte Estado { get; set; }
        public string NombreCategoria { get; set; }
        public List<ComboDTO> Combos { get; set; }
    }
}