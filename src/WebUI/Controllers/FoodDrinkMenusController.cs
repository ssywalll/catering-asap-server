using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CleanArchitecture.WebUI.Controllers;
using CleanArchitecture.Application.FoodDrinkMenus.Queries.GetFoodDrinkMenus;
using CleanArchitecture.Application.FoodDrinkMenus.Commands.CreateFoodDrinkMenu;
using CleanArchitecture.Application.FoodDrinkMenus.Commands.DeleteFoodDrinkMenuCommand;
using CleanArchitecture.Application.FoodDrinkMenus.Commands.UpdateFoodDrinkMenu;
using CleanArchitecture.Application.FoodDrinkMenus.Queries.ExportFoodDrinkMenus;
using CleanArchitecture.Domain.Entities;

namespace WebUI.Controllers
{
    [ApiController]
    public class FoodDrinkMenusController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<FoodDrinkMenusVm>> Get()
        {
            return await Mediator.Send(new GetFoodDrinkMenusQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportFoodDrinkMenusQuery {Id = id});

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<FoodDrinkMenu>> Create(CreateFoodDrinkMenuCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateFoodDrinkMenuCommand command)
        {
           if(id != command.Id)
           {
                return BadRequest();
           }

           await Mediator.Send(command);

           return Ok(); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteFoodDrinkMenuCommand(id));

            return Ok();
        }
    }
}