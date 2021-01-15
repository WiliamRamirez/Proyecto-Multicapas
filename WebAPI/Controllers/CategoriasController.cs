using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Categoria;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.DapperConnection.Categorias;

namespace WebAPI.Controllers
{

    public class CategoriasController : CustomBaseController
    {
        [HttpGet]
        public async Task<List<CategoriaModel>> Get()
        {
            return await Mediator.Send(new Get.RunGet());
        }

        [HttpGet("{id}")]
        public async Task<CategoriaModel> Get(Guid id)
        {
            return await Mediator.Send(new GetId.RunGetId { CategoriaId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(Post.RunPost data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Put(Guid id, Put.RunPut data)
        {
            data.CategoriaId = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new Delete.RunDelete { CategoriaId = id });
        }



    }
}