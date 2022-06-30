using InflowSystem.Modules.Wallets.Core.Wallets.Entities;
using InflowSystem.Shared.Abstractions.Queries;
using System.Linq.Expressions;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Storage
{
    internal interface IWalletStorage
    {
        Task<Wallet> FindAsync(Expression<Func<Wallet, bool>> expression);
        Task<Paged<Wallet>> BrowseAsync(Expression<Func<Wallet, bool>> expression, IPagedQuery query);
    }
}
