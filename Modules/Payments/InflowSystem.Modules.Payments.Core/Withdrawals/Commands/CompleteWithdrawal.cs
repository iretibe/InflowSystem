using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Commands
{
    internal record CompleteWithdrawal(Guid WithdrawalId, string Secret) : ICommand;
}
