using System;

namespace Persistence.DapperConnection.Categorias
{
    public class CategoriaModel
    {
        public Guid CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public byte Estado { get; set; }

    }
}