using InflowSystem.Shared.Abstractions.Contracts;
using InflowSystem.Shared.Abstractions.Events;
using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Modules.Wallets.Application.Owners.Events.External
{
    internal record CustomerVerified(Guid CustomerId) : IEvent;

    [Message("customers")]
    internal class CustomerVerifiedContract : Contract<CustomerVerified>
    {
        public CustomerVerifiedContract()
        {
            RequireAll();
        }
    }
}
