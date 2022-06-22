using InflowSystem.Shared.Abstractions.Contracts;
using InflowSystem.Shared.Abstractions.Events;
using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Modules.Customers.Core.Events.External
{
    internal record UserStateUpdated(Guid UserId, string State) : IEvent;

    [Message("users")]
    internal class UserStateUpdatedContract : Contract<UserStateUpdated>
    {
        public UserStateUpdatedContract()
        {
            RequireAll();
        }
    }
}
