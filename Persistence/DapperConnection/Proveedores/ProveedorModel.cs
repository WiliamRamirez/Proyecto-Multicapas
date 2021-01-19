using System;

namespace Persistence.DapperConnection.Proveedores
{
    public class ProveedorModel
    { 
        public Guid ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public byte Estado { get; set; }
    }
}