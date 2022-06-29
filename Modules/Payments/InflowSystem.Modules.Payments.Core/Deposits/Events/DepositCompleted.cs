using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Payments.Core.Deposits.Events
{
    internal record DepositCompleted(Guid DepositId, Guid CustomerId, string Currency, decimal Amount) : IEvent;
}
