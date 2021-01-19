using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Producto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.DapperConnection.Productos;

namespace WebAPI.Controllers
{
    
    public class ProductosController : CustomBaseController
    {
        [HttpGet]
        public async Task<List<ProductoDTO>> Get()
        {
            return await Mediator.Send(new Get.RunGet());
        }

        [HttpGet("{id}")]
        public async Task<ProductoDTO> Get(Guid id)
        {
            return await Mediator.Send(new GetId.RunGetId{ProductoId = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post( Post.RunPost data )
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Put(Guid id, Put.RunPut data)
        {
            data.ProductoId = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Put(Guid id)
        {
            return await Mediator.Send(new Delete.RunDelete { ProductoId = id });
        }

    }
}