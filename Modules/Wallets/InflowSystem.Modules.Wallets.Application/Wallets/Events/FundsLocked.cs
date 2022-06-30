using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Events
{
    internal record FundsLocked(Guid WalletId, string Currency, decimal Amount) : IEvent;
}
