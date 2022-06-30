using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Wallets.Core.Wallets.Exceptions
{
    public class InvalidTransferAmountException : InflowException
    {
        public decimal Amount { get; }

        public InvalidTransferAmountException(decimal amount) : base($"Transfer has invalid amount: '{amount}'.")
        {
            Amount = amount;
        }
    }
}
