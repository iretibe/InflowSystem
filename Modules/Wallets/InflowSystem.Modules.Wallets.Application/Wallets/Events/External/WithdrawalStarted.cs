using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Events.External
{
    internal record WithdrawalStarted(Guid WithdrawalId, Guid CustomerId, string Currency, decimal Amount) : IEvent;
}
