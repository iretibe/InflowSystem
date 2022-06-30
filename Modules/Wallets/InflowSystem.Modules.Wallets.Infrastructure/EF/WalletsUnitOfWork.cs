using InflowSystem.Shared.Infrastructure.SQLServer;

namespace InflowSystem.Modules.Wallets.Infrastructure.EF
{
    internal class WalletsUnitOfWork : SQLServerUnitOfWork<WalletsDbContext>
    {
        public WalletsUnitOfWork(WalletsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
