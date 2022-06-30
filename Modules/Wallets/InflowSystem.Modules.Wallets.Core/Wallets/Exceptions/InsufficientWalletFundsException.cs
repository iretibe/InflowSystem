using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Wallets.Core.Wallets.Exceptions
{
    internal class InsufficientWalletFundsException : InflowException
    {
        public Guid WalletId { get; }

        public InsufficientWalletFundsException(Guid walletId)
            : base($"Insufficient funds for wallet with ID: '{walletId}'.")
        {
            WalletId = walletId;
        }
    }
}
