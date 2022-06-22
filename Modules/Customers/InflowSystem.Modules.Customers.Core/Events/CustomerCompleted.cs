using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Customers.Core.Events
{
    internal record CustomerCompleted(Guid CustomerId, string Name, string FullName, string Nationality) : IEvent;
}
