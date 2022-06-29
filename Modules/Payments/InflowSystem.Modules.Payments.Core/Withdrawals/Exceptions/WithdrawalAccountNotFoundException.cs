using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Exceptions
{
    public class WithdrawalAccountNotFoundException : InflowException
    {
        public Guid AccountId { get; }
        public Guid CustomerId { get; }

        public WithdrawalAccountNotFoundException(Guid accountId, Guid customerId)
            : base($"Withdrawal account with ID: '{accountId}' for customer with ID: '{customerId}' was not found.")
        {
            AccountId = accountId;
            CustomerId = customerId;
        }
    }
}
