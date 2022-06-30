using InflowSystem.Modules.Wallets.Application.Wallets.DTO;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Queries
{
    internal class BrowseWallets : PagedQuery<WalletDto>
    {
        public Guid? OwnerId { get; set; }
        public string Currency { get; set; }
    }
}
