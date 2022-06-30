using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Wallets.Core.Owners.Exceptions
{
    internal class InvalidTaxIdException : InflowException
    {
        public string TaxId { get; }

        public InvalidTaxIdException(string taxId) : base($"Tax ID: '{taxId}' is invalid.")
        {
            TaxId = taxId;
        }
    }
}
