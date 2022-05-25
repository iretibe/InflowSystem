using InflowSystem.Modules.Users.Core.Entities;

namespace InflowSystem.Modules.Users.Core.Repositories
{
    internal interface IRoleRepository
    {
        Task<Role> GetAsync(string name);
        Task<IReadOnlyList<Role>> GetAllAsync();
        Task AddAsync(Role role);
    }
}
