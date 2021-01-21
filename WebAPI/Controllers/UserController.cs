using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    // Para que el controller no tenga seguridad se usa el (AllowAnonymous)
    [AllowAnonymous]
    public class UserController : CustomBaseController
    {
        [HttpGet("listUser")]
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {
            return await Mediator.Send(new GetUser.RunGetUser());
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUser()
        {
            return await Mediator.Send(new CurrentUser.RunCurrentUser());
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUser.RunRegisterUser data)
        {
            return await Mediator.Send(data);
        }

        //http://localhost:5000/api/user/login
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(Login.RunLogin data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Update(Guid id, UpdateUser.RunUpdateUser data)
        {
            data.Id = id;
            return await Mediator.Send(data);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new DeleteUser.RunDeleteUser{Id = id});
        }



    }
}