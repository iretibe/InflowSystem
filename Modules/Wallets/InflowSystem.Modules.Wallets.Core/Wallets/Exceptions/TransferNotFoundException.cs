using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Wallets.Core.Wallets.Exceptions
{
    public class TransferNotFoundException : InflowException
    {
        public Guid TransferId { get; }

        public TransferNotFoundException(Guid transferId) : base($"Transfer with ID: '{transferId}' was not found.")
        {
            TransferId = transferId;
        }
    }
}
