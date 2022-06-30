using InflowSystem.Modules.Wallets.Application.Wallets.DTO;
using InflowSystem.Modules.Wallets.Application.Wallets.Storage;
using InflowSystem.Modules.Wallets.Core.Wallets.Entities;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;
using InflowSystem.Shared.Abstractions.Queries;
using System.Linq.Expressions;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Queries.Handlers
{
    internal sealed class BrowseWalletsHandler : IQueryHandler<BrowseWallets, Paged<WalletDto>>
    {
        private readonly IWalletStorage _storage;

        public BrowseWalletsHandler(IWalletStorage storage)
        {
            _storage = storage;
        }

        public async Task<Paged<WalletDto>> HandleAsync(BrowseWallets query,
            CancellationToken cancellationToken = default)
        {
            Expression<Func<Wallet, bool>> expression = x => true;

            if (!string.IsNullOrWhiteSpace(query.Currency))
            {
                _ = new Currency(query.Currency);
                expression = expression.And(x => x.Currency == query.Currency);
            }

            if (query.OwnerId.HasValue)
            {
                expression = expression.And(x => x.OwnerId == query.OwnerId);
            }

            var result = await _storage.BrowseAsync(expression, query);
            var wallets = result.Items.Select(x => x.AsDto()).ToList();

            return Paged<WalletDto>.From(result, wallets);
        }
    }
}
