using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Events
{
    internal record WithdrawalAccountAdded(Guid AccountId, Guid CustomerId, string Currency) : IEvent;
}
