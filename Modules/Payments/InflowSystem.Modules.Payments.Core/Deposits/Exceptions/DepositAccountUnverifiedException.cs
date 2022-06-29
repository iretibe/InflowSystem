using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Core.Deposits.Exceptions
{
    internal class DepositAccountUnverifiedException : InflowException
    {
        public Guid AccountId { get; }
        public Guid CustomerId { get; }

        public DepositAccountUnverifiedException(Guid accountId, Guid customerId)
            : base($"Deposit account with ID: '{accountId}' for customer with ID: '{customerId}' is unverified.")
        {
            AccountId = accountId;
            CustomerId = customerId;
        }
    }
}
