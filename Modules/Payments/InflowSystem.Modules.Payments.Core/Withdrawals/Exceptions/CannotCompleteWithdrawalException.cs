using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Exceptions
{
    internal class CannotCompleteWithdrawalException : InflowException
    {
        public Guid DepositId { get; }

        public CannotCompleteWithdrawalException(Guid depositId)
            : base($"Withdrawal with ID: '{depositId}' cannot be completed.")
        {
            DepositId = depositId;
        }
    }
}
