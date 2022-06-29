using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Events
{
    internal record WithdrawalRejected(Guid WithdrawalId, Guid CustomerId, string Currency, decimal Amount) : IEvent;
}
