using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Users.Core.Events
{
    internal record UserStateUpdated(Guid UserId, string State) : IEvent;
}
