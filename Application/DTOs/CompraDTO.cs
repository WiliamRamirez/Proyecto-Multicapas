using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class CompraDTO
    {
        public Guid CompraId { get; set; }
        public DateTime FechaCompra { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public Decimal Correlativo { get; set; }
        public Decimal Igv { get; set; }
        public Decimal Descuento { get; set; }
        public string NombreProveedor { get; set; }
        public byte Estado { get; set; }

        public List<DetalleCompraDTO> DetallesCompras { get; set; }

    }
}