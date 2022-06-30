using InflowSystem.Modules.Wallets.Application.Wallets.DTO;
using InflowSystem.Modules.Wallets.Application.Wallets.Storage;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Queries.Handlers
{
    internal sealed class GetTransferHandler : IQueryHandler<GetTransfer, TransferDetailsDto>
    {
        private readonly ITransferStorage _storage;

        public GetTransferHandler(ITransferStorage storage)
        {
            _storage = storage;
        }

        public async Task<TransferDetailsDto> HandleAsync(GetTransfer query, CancellationToken cancellationToken = default)
        {
            var transfer = await _storage.FindAsync(x => x.Id == query.TransferId);

            return transfer?.AsDetailsDto();
        }
    }
}
