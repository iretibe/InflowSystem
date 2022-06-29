using InflowSystem.Modules.Payments.Core.Deposits.Domain.Entities;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;

namespace InflowSystem.Modules.Payments.Core.Deposits.Domain.Repositories
{
    internal interface IDepositAccountRepository
    {
        Task<DepositAccount> GetAsync(Guid id);
        Task<DepositAccount> GetAsync(Guid customerId, Currency currency);
        Task AddAsync(DepositAccount depositAccount);
    }
}
