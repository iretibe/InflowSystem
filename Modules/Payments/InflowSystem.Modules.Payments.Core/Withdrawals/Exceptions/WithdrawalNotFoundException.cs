using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Exceptions
{
    public class WithdrawalNotFoundException : InflowException
    {
        public Guid DepositId { get; }

        public WithdrawalNotFoundException(Guid depositId) : base($"Withdrawal with ID: '{depositId}' was not found.")
        {
            DepositId = depositId;
        }
    }
}
