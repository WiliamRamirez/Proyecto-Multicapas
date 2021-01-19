using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Combos;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CombosController : CustomBaseController
    {
        [HttpGet]
        public async Task<List<ComboDTO>> Get()
        {
            return await Mediator.Send(new Get.RunGet());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(Post.RunPost data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Post(Guid id, Put.RunPut data)
        {
            data.ComboId = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new Delete.RunDelete { ComboId = id });
        }


    }
}