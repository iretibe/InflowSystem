using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Shared.Abstractions.Kernel.Exceptions
{
    public class InvalidCurrencyException : InflowException
    {
        public string Currency { get; }

        public InvalidCurrencyException(string currency) : base($"Currency: '{currency}' is invalid.")
        {
            Currency = currency;
        }
    }
}
