using InflowSystem.Modules.Payments.Shared.Entities;

namespace InflowSystem.Modules.Payments.Shared.Repositories
{
    internal interface ICustomerRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
    }
}
