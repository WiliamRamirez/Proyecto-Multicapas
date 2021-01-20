using System;

namespace Application.DTOs
{
    public class DetalleCompraCreationDTO
    {
        public Decimal Cantidad { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public Decimal SubTotal { get; set; }
        public Guid ProductoId { get; set; }
    }
}