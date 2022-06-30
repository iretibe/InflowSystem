using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Wallets.Core.Owners.Exceptions
{
    public class OwnerNotFoundException : InflowException
    {
        public Guid OwnerId { get; }

        public OwnerNotFoundException(Guid ownerId) : base($"Owner with ID: '{ownerId}' was not found.")
        {
            OwnerId = ownerId;
        }
    }
}
