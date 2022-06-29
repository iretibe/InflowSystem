using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Core.Deposits.Exceptions
{
    internal class DepositNotFoundException : InflowException
    {
        public Guid DepositId { get; }

        public DepositNotFoundException(Guid depositId) : base($"Deposit with ID: '{depositId}' was not found.")
        {
            DepositId = depositId;
        }
    }
}
