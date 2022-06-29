using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Payments.Core.Deposits.Events.External
{
    internal record CustomerCompleted(Guid CustomerId, string FullName, string Nationality) : IEvent;
}
