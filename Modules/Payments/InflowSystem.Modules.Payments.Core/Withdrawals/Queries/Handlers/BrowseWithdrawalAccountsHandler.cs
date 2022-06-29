using InflowSystem.Modules.Payments.Core.DAL;
using InflowSystem.Modules.Payments.Core.Withdrawals.DTO;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;
using InflowSystem.Shared.Abstractions.Queries;
using InflowSystem.Shared.Infrastructure.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Queries.Handlers
{
    internal sealed class BrowseWithdrawalAccountsHandler : IQueryHandler<BrowseWithdrawalAccounts, Paged<WithdrawalAccountDto>>
    {
        private readonly PaymentsDbContext _dbContext;

        public BrowseWithdrawalAccountsHandler(PaymentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Paged<WithdrawalAccountDto>> HandleAsync(BrowseWithdrawalAccounts query,
            CancellationToken cancellationToken = default)
        {
            var accounts = _dbContext.WithdrawalAccounts.AsQueryable();

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
                .Select(x => new WithdrawalAccountDto
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
