using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Usuario : IdentityUser
    {
        public string NombreCompleto { get; set; }
    }
}