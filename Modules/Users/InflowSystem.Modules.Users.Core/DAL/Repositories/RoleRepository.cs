using InflowSystem.Modules.Users.Core.Entities;
using InflowSystem.Modules.Users.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Modules.Users.Core.DAL.Repositories
{
    internal class RoleRepository : IRoleRepository
    {
        private readonly UsersDbContext _context;
        private readonly DbSet<Role> _roles;

        public RoleRepository(UsersDbContext context)
        {
            _context = context;
            _roles = context.Roles;
        }

        public Task AddAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
