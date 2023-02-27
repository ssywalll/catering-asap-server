using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.BankAccounts.Commands.CreateBankAccount;
using CleanArchitecture.Application.BankAccounts.Queries.GetBankAccounts;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CleanArchitecture.Application.BankAccounts.Queries.ExportBankAccounts;
using CleanArchitecture.Application.BankAccounts.Commands.DeleteBankAccount;
using CleanArchitecture.Application.BankAccounts.Commands.UpdateBankAccount;
using MediatR;

namespace WebUI.Controllers
{
    [Authorize]
    [ApiController]
    public class BankAccountsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BankAccountsVm>> Get([FromQuery] GetBankAccountQuery command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateBankAccountCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var vm = await Mediator.Send(new ExportBankAccountsQuery { Id = Id });
            return Ok(vm);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] DeleteBankAccountCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateBankAccountCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

    }
}