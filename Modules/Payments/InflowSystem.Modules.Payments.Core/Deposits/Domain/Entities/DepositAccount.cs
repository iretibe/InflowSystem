﻿using InflowSystem.Modules.Payments.Shared.Entities;
using InflowSystem.Modules.Payments.Shared.ValueObjects;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;

namespace InflowSystem.Modules.Payments.Core.Deposits.Domain.Entities
{
    internal class DepositAccount
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public Currency Currency { get; private set; }
        public Iban Iban { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IEnumerable<Deposit> Deposits { get; private set; }

        private DepositAccount()
        {
        }

        public DepositAccount(Guid id, Guid customerId, Currency currency, Iban iban, DateTime createdAt)
        {
            Id = id;
            CustomerId = customerId;
            Currency = currency;
            Iban = iban;
            CreatedAt = createdAt;
        }

        public Deposit CreateDeposit(Guid depositId, Amount amount, DateTime createdAt)
            => new(depositId, Id, amount, Currency, createdAt);
    }
}
