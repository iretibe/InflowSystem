using InflowSystem.Shared.Abstractions.Contracts;
using InflowSystem.Shared.Abstractions.Events;
using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Modules.Customers.Core.Events.External
{
    internal record SignedUp(Guid UserId, string Email, string Role) : IEvent;

    [Message("users")]
    internal class SignedUpContract : Contract<SignedUp>
    {
        public SignedUpContract(string module)
        {
            RequireAll();
        }
    }
}
