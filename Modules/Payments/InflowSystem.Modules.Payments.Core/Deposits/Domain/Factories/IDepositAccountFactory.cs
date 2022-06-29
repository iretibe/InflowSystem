using InflowSystem.Modules.Payments.Core.Deposits.Domain.Entities;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;

namespace InflowSystem.Modules.Payments.Core.Deposits.Domain.Factories
{
    internal interface IDepositAccountFactory
    {
        DepositAccount Create(Guid customerId, Nationality nationality, Currency currency);
    }
}
