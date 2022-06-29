﻿using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Commands
{
    internal record StartWithdrawal(Guid AccountId, Guid CustomerId, string Currency, decimal Amount) : ICommand
    {
        public Guid WithdrawalId { get; init; } = Guid.NewGuid();
    }
}
