using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Wallets.Core.Wallets.Exceptions
{
    public class InvalidTransferCurrencyException : InflowException
    {
        public string Currency { get; }

        public InvalidTransferCurrencyException(string currency) : base($"Transfer has invalid currency: '{currency}'.")
        {
            Currency = currency;
        }
    }
}
