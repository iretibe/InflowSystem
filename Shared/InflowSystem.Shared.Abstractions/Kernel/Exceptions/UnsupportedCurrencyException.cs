using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Shared.Abstractions.Kernel.Exceptions
{
    public class UnsupportedCurrencyException : InflowException
    {
        public string Currency { get; }

        public UnsupportedCurrencyException(string currency) : base($"Currency: '{currency}' is unsupported.")
        {
            Currency = currency;
        }
    }
}
