using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Wallets.Core.Wallets.Exceptions
{
    public class WalletAlreadyExistsException : InflowException
    {
        public Guid OwnerId { get; }
        public string Currency { get; }

        public WalletAlreadyExistsException(Guid ownerId, string currency)
            : base($"Wallet for owner with ID: '{ownerId}', currency: '{currency}' already exists.")
        {
            OwnerId = ownerId;
            Currency = currency;
        }
    }
}
