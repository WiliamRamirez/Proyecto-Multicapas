using System;

namespace Persistence.DapperConnection.Combos
{
    public class ComboModel
    {
        public Guid ComboId { get; set; }
        public string NombreCombo { get; set; }
        public int Cantidad { get; set; }
        public Decimal PrecioCombo { get; set; }
        public byte Estado { get; set; }
        public Guid ProductoId { get; set; }
    }
}