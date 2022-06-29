using InflowSystem.Modules.Payments.Core.Withdrawals.Domain.Entities;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Domain.Repositories
{
    internal interface IWithdrawalAccountRepository
    {
        Task<bool> ExistsAsync(Guid customerId, Currency currency);
        Task<WithdrawalAccount> GetAsync(Guid id);
        Task<WithdrawalAccount> GetAsync(Guid customerId, Currency currency);
        Task AddAsync(WithdrawalAccount withdrawalAccount);
    }
}
