using InflowSystem.Modules.Wallets.Application.Wallets.DTO;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Queries
{
    internal class GetTransfer : IQuery<TransferDetailsDto>
    {
        public Guid? TransferId { get; set; }
    }
}
