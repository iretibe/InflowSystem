using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Payments.Core.Deposits.Events
{
    internal record DepositAccountAdded(Guid AccountId, Guid CustomerId, string Currency) : IEvent;
}
