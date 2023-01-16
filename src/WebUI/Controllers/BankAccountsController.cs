using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.BankAccounts.Commands.CreateBankAccount;
using CleanArchitecture.Application.BankAccounts.Commands.DeleteBankAccount;
using CleanArchitecture.Application.BankAccounts.Commands.UpdateBankAccount;
using CleanArchitecture.Application.BankAccounts.Queries.ExportBankAccounts;
using CleanArchitecture.Application.BankAccounts.Queries.GetBankAccounts;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    public class BankAccountsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BankAccountsVm>> Get()
        {
            return await Mediator.Send(new GetBankAccountQuery());
        }

        [HttpPost]
        public async Task<ActionResult<BankAccount>> Create(CreateBankAccountCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{Id}")]
        public  async Task<IActionResult> Get(int Id)
        {
            var vm = await Mediator.Send(new ExportBankAccountsQuery{Id = Id});
            return Ok(vm);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Update(int Id, UpdateBankAccountCommand command)
        {
            if(Id != command.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBankAccountCommand(id));

            return Ok();
        }
    }
}