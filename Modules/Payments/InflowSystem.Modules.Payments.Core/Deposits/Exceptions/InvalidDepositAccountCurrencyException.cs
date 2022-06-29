using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Core.Deposits.Exceptions
{
    internal class InvalidDepositAccountCurrencyException : InflowException
    {
        public Guid AccountId { get; }
        public string Currency { get; }

        public InvalidDepositAccountCurrencyException(Guid accountId, string currency)
            : base($"Deposit account with ID: '{accountId}' has invalid currency: '{currency}'.")
        {
            AccountId = accountId;
            Currency = currency;
        }
    }
}
