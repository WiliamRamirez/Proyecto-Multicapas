using System.Collections.Generic;
using System;
namespace Domain.Entities
{
    public class Proveedor
    {
        public Guid ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        //Link a la Tabla Proveedor
        public ICollection<Compra> Compras { get; set; }
    }
}