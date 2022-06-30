using InflowSystem.Modules.Wallets.Application.Wallets.Storage;
using InflowSystem.Modules.Wallets.Core.Wallets.Entities;
using InflowSystem.Modules.Wallets.Infrastructure.EF;
using InflowSystem.Shared.Abstractions.Queries;
using InflowSystem.Shared.Infrastructure.SQLServer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InflowSystem.Modules.Wallets.Infrastructure.Storage
{
    internal sealed class WalletStorage : IWalletStorage
    {
        private readonly DbSet<Wallet> _wallets;

        public WalletStorage(WalletsDbContext dbContext)
        {
            _wallets = dbContext.Wallets;
        }

        public Task<Wallet> FindAsync(Expression<Func<Wallet, bool>> expression)
            => _wallets
                .AsNoTracking()
                .AsQueryable()
                .Where(expression)
                .Include(x => x.Transfers)
                .SingleOrDefaultAsync();

        public Task<Paged<Wallet>> BrowseAsync(Expression<Func<Wallet, bool>> expression, IPagedQuery query)
            => _wallets
                .AsNoTracking()
                .AsQueryable()
                .Where(expression)
                .OrderBy(x => x.CreatedAt)
                .PaginateAsync(query);
    }
}
