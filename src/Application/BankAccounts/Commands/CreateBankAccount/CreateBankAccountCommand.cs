using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Context;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Net;

namespace CleanArchitecture.Application.BankAccounts.Commands.CreateBankAccount
{
    public record CreateBankAccountCommand : UseAprizax, IRequest
    {
        public string BankNumber { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string BankName { get; init; } = string.Empty;

    }

    public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public CreateBankAccountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new NotFoundException("Request anda kosong!", HttpStatusCode.BadRequest);

            var tokenInfo = request.GetTokenInfo();

            if (tokenInfo.Is_Valid is false)
                throw new NotFoundException("Token tidak ditemukan", HttpStatusCode.BadRequest);

            var entity = new BankAccount
            {
                Bank_Number = request.BankNumber,
                Name = request.Name.ToUpper(),
                Bank_Name = request.BankName.ToUpper(),
                User_Id = tokenInfo.Owner_Id ?? 0
            };

            _context.BankAccounts.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}