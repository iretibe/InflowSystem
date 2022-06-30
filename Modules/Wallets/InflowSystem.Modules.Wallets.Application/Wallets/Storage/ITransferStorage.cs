using InflowSystem.Modules.Wallets.Core.Wallets.Entities;
using InflowSystem.Shared.Abstractions.Queries;
using System.Linq.Expressions;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Storage
{
    internal interface ITransferStorage
    {
        Task<Transfer> FindAsync(Expression<Func<Transfer, bool>> expression);
        Task<Paged<Transfer>> BrowseAsync(Expression<Func<Transfer, bool>> expression, IPagedQuery query);
    }
}
