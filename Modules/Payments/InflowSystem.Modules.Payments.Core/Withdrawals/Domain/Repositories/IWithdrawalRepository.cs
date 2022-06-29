using InflowSystem.Modules.Payments.Core.Withdrawals.Domain.Entities;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Domain.Repositories
{
    internal interface IWithdrawalRepository
    {
        Task<Withdrawal> GetAsync(Guid id);
        Task AddAsync(Withdrawal withdrawal);
        Task UpdateAsync(Withdrawal withdrawal);
    }
}
