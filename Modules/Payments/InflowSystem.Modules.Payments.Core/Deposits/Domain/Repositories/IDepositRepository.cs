using InflowSystem.Modules.Payments.Core.Deposits.Domain.Entities;

namespace InflowSystem.Modules.Payments.Core.Deposits.Domain.Repositories
{
    internal interface IDepositRepository
    {
        Task<Deposit> GetAsync(Guid id);
        Task AddAsync(Deposit deposit);
        Task UpdateAsync(Deposit deposit);
    }
}
