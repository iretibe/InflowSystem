using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Payments.Core.Deposits.Commands
{
    internal record CompleteDeposit(Guid DepositId, string Secret) : ICommand;
}
