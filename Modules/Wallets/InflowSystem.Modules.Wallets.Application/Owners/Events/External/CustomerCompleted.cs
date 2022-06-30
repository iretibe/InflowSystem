using InflowSystem.Shared.Abstractions.Contracts;
using InflowSystem.Shared.Abstractions.Events;
using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Modules.Wallets.Application.Owners.Events.External
{
    internal record CustomerCompleted(Guid CustomerId, string Name, string FullName, string Nationality) : IEvent;

    [Message("customers")]
    internal class CustomerCompletedContract : Contract<CustomerCompleted>
    {
        public CustomerCompletedContract()
        {
            RequireAll();
        }
    }
}
