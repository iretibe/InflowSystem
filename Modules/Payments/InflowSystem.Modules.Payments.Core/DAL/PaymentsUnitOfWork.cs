using InflowSystem.Shared.Infrastructure.SQLServer;

namespace InflowSystem.Modules.Payments.Core.DAL
{
    internal class PaymentsUnitOfWork : SQLServerUnitOfWork<PaymentsDbContext>
    {
        public PaymentsUnitOfWork(PaymentsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
