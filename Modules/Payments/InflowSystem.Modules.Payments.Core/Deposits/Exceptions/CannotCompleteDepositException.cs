using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Core.Deposits.Exceptions
{
    internal class CannotCompleteDepositException : InflowException
    {
        public Guid DepositId { get; }

        public CannotCompleteDepositException(Guid depositId) : base($"Deposit with ID: '{depositId}' cannot be completed.")
        {
            DepositId = depositId;
        }
    }
}
