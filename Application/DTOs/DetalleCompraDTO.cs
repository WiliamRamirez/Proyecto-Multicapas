using System;

namespace Application.DTOs
{
    public class DetalleCompraDTO
    {
        public Guid DetalleCompraId { get; set; }
        public Decimal Cantidad { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public Decimal SubTotal { get; set; }
        public string NombreProducto { get; set; }
        public byte Estado { get; set; }
    }
}