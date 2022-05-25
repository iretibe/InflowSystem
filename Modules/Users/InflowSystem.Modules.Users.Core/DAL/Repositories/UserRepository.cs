using InflowSystem.Modules.Users.Core.Entities;
using InflowSystem.Modules.Users.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Modules.Users.Core.DAL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
            _users = _context.Users;
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
