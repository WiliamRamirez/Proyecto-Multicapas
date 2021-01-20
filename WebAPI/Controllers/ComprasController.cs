using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Compra;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ComprasController : CustomBaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<CompraDTO>>> Get()
        {
            return await Mediator.Send(new Get.RunGet());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompraDTO>> Get(Guid id)
        {
            return await Mediator.Send(new GetId.RunGetId{CompraId = id});
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> Post(Post.RunPost data)
        {
            return await Mediator.Send(data);
        }
    }
}