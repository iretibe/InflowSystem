using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Payments.Core.Deposits.Events.External
{
    internal record CustomerLocked(Guid CustomerId) : IEvent;
}
