using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Shared.Exceptions
{
    internal class InvalidIbanException : InflowException
    {
        public string Iban { get; }

        public InvalidIbanException(string iban) : base($"IBAN: '{iban}' is invalid.")
        {
            Iban = iban;
        }
    }
}
