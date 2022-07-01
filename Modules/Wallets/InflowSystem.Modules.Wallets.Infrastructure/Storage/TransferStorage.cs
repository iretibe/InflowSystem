using InflowSystem.Modules.Wallets.Application.Wallets.Storage;
using InflowSystem.Modules.Wallets.Core.Wallets.Entities;
using InflowSystem.Modules.Wallets.Infrastructure.EF;
using InflowSystem.Shared.Abstractions.Queries;
using InflowSystem.Shared.Infrastructure.SQLServer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InflowSystem.Modules.Wallets.Infrastructure.Storage
{
    internal sealed class TransferStorage : ITransferStorage
    {
        private readonly DbSet<Transfer> _transfers;

        public TransferStorage(WalletsDbContext dbContext)
        {
            _transfers = dbContext.Transfers;
        }

        public Task<Transfer> FindAsync(Expression<Func<Transfer, bool>> expression)
            => _transfers
                .AsNoTracking()
                .AsQueryable()
                .Where(expression)
                .SingleOrDefaultAsync();

        public Task<Paged<Transfer>> BrowseAsync(Expression<Func<Transfer, bool>> expression, IPagedQuery query)
            => _transfers
                .AsNoTracking()
                .AsQueryable()
                .Where(expression)
                .OrderBy(x => x.CreatedAt)
                .PaginateAsync(query);
    }
}
