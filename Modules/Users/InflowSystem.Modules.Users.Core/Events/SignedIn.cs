using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Users.Core.Events
{
    internal record SignedIn(Guid UserId) : IEvent;
}
