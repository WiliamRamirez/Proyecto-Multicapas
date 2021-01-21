using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class DataAdmin
    {
        public static async Task InsertData(SistemaDbContext context, UserManager<Usuario> userManager)
        {
            if (!userManager.Users.Any())
            {
                var usuario = new Usuario { NombreCompleto = "admin", UserName = "admin", Email = "admin", Estado = 1, isAdmin = 1};
                await userManager.CreateAsync(usuario, "Password1234$");
            }
        }
    }
}