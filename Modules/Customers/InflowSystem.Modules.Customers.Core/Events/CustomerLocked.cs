using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Customers.Core.Events
{
    internal record CustomerLocked(Guid CustomerId) : IEvent;
}
