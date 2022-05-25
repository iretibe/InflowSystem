using InflowSystem.Shared.Infrastructure.SQLServer;

namespace InflowSystem.Modules.Users.Core.DAL
{
    internal class UsersUnitOfWork : SQLServerUnitOfWork<UsersDbContext>
    {
        public UsersUnitOfWork(UsersDbContext dbContext) : base(dbContext)
        {
        }
    }
}
