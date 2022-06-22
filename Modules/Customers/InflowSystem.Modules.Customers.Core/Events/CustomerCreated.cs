using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Customers.Core.Events
{
    internal record CustomerCreated(Guid CustomerId) : IEvent;
}
