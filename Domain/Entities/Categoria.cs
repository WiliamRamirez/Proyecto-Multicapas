using System.Collections.Generic;
using System;
namespace Domain.Entities
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; }


    }
}