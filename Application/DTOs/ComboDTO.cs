using System;

namespace Application.DTOs
{
    public class ComboDTO
    {
        public Guid ComboId { get; set; }
        public string NombreCombo { get; set; }
        public int Cantidad { get; set; }
        public Decimal PrecioCombo { get; set; }
        public byte Estado { get; set; }
    }
}