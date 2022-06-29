using InflowSystem.Modules.Payments.Core.DAL;
using InflowSystem.Modules.Payments.Core.Deposits.Domain.Entities;
using InflowSystem.Modules.Payments.Core.Deposits.DTO;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;
using InflowSystem.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Modules.Payments.Core.Deposits.Queries.Handlers
{
    internal class BrowseDepositsHandler : IQueryHandler<BrowseDeposits, Paged<DepositDto>>
    {
        private readonly PaymentsDbContext _dbContext;

        public BrowseDepositsHandler(PaymentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Paged<DepositDto>> HandleAsync(BrowseDeposits query, CancellationToken cancellationToken = default)
        {
            var deposits = _dbContext.Deposits.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Currency))
            {
                _ = new Currency(query.Currency);
                deposits = deposits.Where(x => x.Currency == query.Currency);
            }

            if (!string.IsNullOrWhiteSpace(query.Status) &&
                Enum.TryParse<DepositStatus>(query.Status, true, out var status))
            {
                deposits = deposits.Where(x => x.Status == status);
            }

            if (query.AccountId.HasValue)
            {
                deposits = deposits.Where(x => x.AccountId == query.AccountId &&
                                               (!query.CustomerId.HasValue || x.Account.CustomerId == query.CustomerId));
            }

            if (query.CustomerId.HasValue)
            {
                deposits = deposits.Where(x => x.Account.CustomerId == query.CustomerId);
            }

            return deposits.AsNoTracking()
                .Include(x => x.Account)
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new DepositDto
                {
                    DepositId = x.Id,
                    AccountId = x.AccountId,
                    CustomerId = x.Account.CustomerId,
                    Amount = x.Amount,
                    Currency = x.Currency,
                    Status = x.Status.ToString().ToLowerInvariant(),
                    CreatedAt = x.CreatedAt,
                    ProcessedAt = x.ProcessedAt
                })
                .PaginateAsync(query, cancellationToken);
        }
    }
}
