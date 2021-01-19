using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Proveedor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.DapperConnection.Proveedores;

namespace WebAPI.Controllers
{
    public class ProveedoresController : CustomBaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<ProveedorModel>>> Get()
        {
            return await Mediator.Send(new Get.RunGet());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorModel>> Get(Guid id)
        {
            return await Mediator.Send(new GetId.RunGetId { ProveedorId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(Post.RunPost data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Post(Guid id, Put.RunPut data)
        {
            data.ProveedorId = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Post(Guid id)
        {
            return await Mediator.Send(new Delete.RunDelete { ProveedorId = id });
        }
    }
}