using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Numerics;


namespace CleanArchitecture.Application.BankAccounts.Commands.CreateBankAccount
{
    public record CreateBankAccountCommand : IRequest<BankAccount>
    {
        public string Number { get; init; } = string.Empty;
        public string Name { get; init; }  = string.Empty;
        public string Bank_User { get; init; } = string.Empty;
        public int User_Id { get; init; }
    }

    public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, BankAccount>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateBankAccountCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BankAccount> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = new BankAccount();
            
                entity.Number = request.Number;
                entity.Name = request.Name;
                entity.Bank_User = request.Bank_User;
                entity.User_Id = request.User_Id;
            

            _context.BankAccounts.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}