using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Users.Core.Events
{
    internal record SignedUp(Guid UserId, string Email, string Role) : IEvent;
}
