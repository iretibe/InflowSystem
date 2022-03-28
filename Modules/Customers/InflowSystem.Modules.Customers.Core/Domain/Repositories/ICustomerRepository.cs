using InflowSystem.Modules.Customers.Core.Domain.Entities;

namespace InflowSystem.Modules.Customers.Core.Domain.Repositories
{
    internal interface ICustomerRepository
    {
        Task<bool> ExistenceAsync(string name);
        Task<Customer> GetAsync(Guid id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
    }
}
