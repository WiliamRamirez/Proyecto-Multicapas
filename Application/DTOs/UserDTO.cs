using System;

namespace Application.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}