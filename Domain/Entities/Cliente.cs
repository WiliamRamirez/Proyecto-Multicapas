using System.Collections.Generic;
using System;
namespace Domain.Entities
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string NombreCompleto { get; set; }
        public string Sexo { get; set; }
        public string Dni { get; set; }
        public string Ruc { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        public ICollection<Venta> Ventas { get; set; }
    }
}