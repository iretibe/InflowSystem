using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Exceptions
{
    internal class CannotRejectWithdrawalException : InflowException
    {
        public Guid DepositId { get; }

        public CannotRejectWithdrawalException(Guid depositId)
            : base($"Withdrawal with ID: '{depositId}' cannot be rejected.")
        {
            DepositId = depositId;
        }
    }
}
