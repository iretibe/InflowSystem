using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Events.External
{
    internal record DepositAccountAdded(Guid AccountId, Guid CustomerId, string Currency) : IEvent;
}
