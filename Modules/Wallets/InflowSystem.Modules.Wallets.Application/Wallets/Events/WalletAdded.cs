using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Events
{
    internal record WalletAdded(Guid WalletId, Guid OwnerId, string Currency) : IEvent;
}
