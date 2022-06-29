using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Core.Deposits.Exceptions
{
    internal class DepositAccountAlreadyExistsException : InflowException
    {
        public Guid CustomerId { get; }
        public string Currency { get; }

        public DepositAccountAlreadyExistsException(Guid customerId, string currency)
            : base($"Deposit account for customer with ID: '{customerId}', currency: '{currency}' already exists.")
        {
            CustomerId = customerId;
            Currency = currency;
        }
    }
}
