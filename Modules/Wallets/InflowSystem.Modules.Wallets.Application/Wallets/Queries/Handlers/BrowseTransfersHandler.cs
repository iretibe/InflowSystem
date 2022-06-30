using InflowSystem.Modules.Wallets.Application.Wallets.DTO;
using InflowSystem.Modules.Wallets.Application.Wallets.Storage;
using InflowSystem.Modules.Wallets.Core.Wallets.Entities;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;
using InflowSystem.Shared.Abstractions.Queries;
using System.Linq.Expressions;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Queries.Handlers
{
    internal sealed class BrowseTransfersHandler : IQueryHandler<BrowseTransfers, Paged<TransferDto>>
    {
        private readonly ITransferStorage _storage;

        public BrowseTransfersHandler(ITransferStorage storage)
        {
            _storage = storage;
        }

        public async Task<Paged<TransferDto>> HandleAsync(BrowseTransfers query,
            CancellationToken cancellationToken = default)
        {
            Expression<Func<Transfer, bool>> expression = x => true;

            if (!string.IsNullOrWhiteSpace(query.Currency))
            {
                _ = new Currency(query.Currency);
                expression = expression.And(x => x.Currency == query.Currency);
            }

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                expression = expression.And(x => x.Name == query.Name);
            }

            var result = await _storage.BrowseAsync(expression, query);
            var transfers = result.Items.Select(x => x.AsDto()).ToList();

            return Paged<TransferDto>.From(result, transfers);
        }
    }
}
