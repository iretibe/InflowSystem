using InflowSystem.Modules.Users.Core.DAL;
using InflowSystem.Modules.Users.Core.DTO;
using InflowSystem.Modules.Users.Core.Entities;
using InflowSystem.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Modules.Users.Core.Queries.Handlers
{
    internal sealed class BrowseUsersHandler : IQueryHandler<BrowseUsers, Paged<UserDto>>
    {
        private readonly UsersDbContext _dbContext;

        public BrowseUsersHandler(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Paged<UserDto>> HandleAsync(BrowseUsers query, CancellationToken cancellationToken = default)
        {
            var users = _dbContext.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                users = users.Where(x => x.Email == query.Email);
            }

            if (!string.IsNullOrWhiteSpace(query.Role))
            {
                users = users.Where(x => x.RoleId == query.Role);
            }

            if (!string.IsNullOrWhiteSpace(query.State) && Enum.TryParse<UserState>(query.State, true, out var state))
            {
                users = users.Where(x => x.State == state);
            }

            return users.AsNoTracking()
                .Include(x => x.Role)
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => x.AsDto())
                .PaginateAsync(query, cancellationToken);
        }
    }
}
