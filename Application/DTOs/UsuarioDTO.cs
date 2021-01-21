using System;

namespace Application.DTOs
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte Estado { get; set; }
        public byte isAdmin { get; set; }
    }
}