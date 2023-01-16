using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Carts.Commands.CreateCart;
using CleanArchitecture.Application.Carts.Commands.DeleteCart;
using CleanArchitecture.Application.Carts.Commands.UpdateCart;
using CleanArchitecture.Application.Carts.Queries.ExportCarts;
using CleanArchitecture.Application.Carts.Queries.GetCarts;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebUI.Controllers
{
    [ApiController]
    public class CartsController : ApiControllerBase
    {
       [HttpGet]
        public async Task<ActionResult<CartsVm>> Get()
        {
            return await Mediator.Send(new GetCartsQuery());
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportCartsQuery {Id = id});
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCartsCommand command)   
        {
            if(id != command.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return Ok();
        }                                                                                             

       [HttpPost]
       public async Task<ActionResult<Cart>> Create(CreateCartCommand command)
       {
            return await Mediator.Send(command);
       }

       [HttpDelete("{id}")]
       public async Task<ActionResult> Delete(int id)
       {
            await Mediator.Send(new DeleteCartCommand(id));

            return Ok();
       }
    }
}