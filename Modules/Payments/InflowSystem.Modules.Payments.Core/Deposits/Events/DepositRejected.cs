using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Payments.Core.Deposits.Events
{
    internal record DepositRejected(Guid DepositId, Guid CustomerId, string Currency, decimal Amount) : IEvent;
}
