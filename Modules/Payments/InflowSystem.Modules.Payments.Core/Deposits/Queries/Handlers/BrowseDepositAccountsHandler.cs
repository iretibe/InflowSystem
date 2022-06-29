using InflowSystem.Modules.Payments.Core.DAL;
using InflowSystem.Modules.Payments.Core.Deposits.DTO;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;
using InflowSystem.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Modules.Payments.Core.Deposits.Queries.Handlers
{
    internal class BrowseDepositAccountsHandler : IQueryHandler<BrowseDepositAccounts, Paged<DepositAccountDto>>
    {
        private readonly PaymentsDbContext _dbContext;

        public BrowseDepositAccountsHandler(PaymentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Paged<DepositAccountDto>> HandleAsync(BrowseDepositAccounts query, CancellationToken cancellationToken = default)
        {
            var accounts = _dbContext.DepositAccounts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Currency))
            {
                _ = new Currency(query.Currency);
                accounts = accounts.Where(x => x.Currency == query.Currency);
            }

            if (query.CustomerId.HasValue)
            {
                accounts = accounts.Where(x => x.CustomerId == query.CustomerId);
            }

            return accounts.AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new DepositAccountDto
                {
                    AccountId = x.Id,
                    CustomerId = x.CustomerId,
                    Currency = x.Currency,
                    Iban = x.Iban,
                    CreatedAt = x.CreatedAt
                })
                .PaginateAsync(query, cancellationToken);
        }
    }
}
