using System.Threading.Tasks;
using Application.DTOs;
using Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    // Para que el controller no tenga seguridad se usa el (AllowAnonymous)
    [AllowAnonymous]
    public class UserController : CustomBaseController
    {
        //http://localhost:5000/api/user/login
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(Login.RunLogin data)
        {
            return await Mediator.Send(data);
        }
    }
}