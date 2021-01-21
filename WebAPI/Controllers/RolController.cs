using System.Threading.Tasks;
using Application.Security.Roles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class RolController : CustomBaseController
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> NewRol(NewRol.RunNewRol data)
        {
            return await Mediator.Send(data);
        }      
    }
}