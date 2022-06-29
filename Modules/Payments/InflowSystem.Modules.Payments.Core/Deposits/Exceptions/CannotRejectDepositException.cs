using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Core.Deposits.Exceptions
{
    internal class CannotRejectDepositException : InflowException
    {
        public Guid DepositId { get; }

        public CannotRejectDepositException(Guid depositId) : base($"Deposit with ID: '{depositId}' cannot be rejected.")
        {
            DepositId = depositId;
        }
    }
}
