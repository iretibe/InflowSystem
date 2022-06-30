using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Events.External
{
    internal record DepositCompleted(Guid DepositId, Guid CustomerId, string Currency, decimal Amount) : IEvent;
}
