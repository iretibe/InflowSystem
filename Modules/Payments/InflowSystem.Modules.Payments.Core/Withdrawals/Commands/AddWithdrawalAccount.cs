﻿using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Commands
{
    internal record AddWithdrawalAccount(Guid CustomerId, string Currency, string Iban) : ICommand
    {
        public Guid AccountId { get; init; } = Guid.NewGuid();
    }
}
