using InflowSystem.Modules.Payments.Core.Deposits.Domain.Entities;
using InflowSystem.Modules.Payments.Core.Withdrawals.Domain.Entities;
using InflowSystem.Modules.Payments.Shared.Entities;
using InflowSystem.Shared.Infrastructure.Messaging.Outbox;
using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Modules.Payments.Core.DAL
{
    internal class PaymentsDbContext : DbContext
    {
        public DbSet<InboxMessage> Inbox { get; set; }
        public DbSet<OutboxMessage> Outbox { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DepositAccount> DepositAccounts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }
        public DbSet<WithdrawalAccount> WithdrawalAccounts { get; set; }

        public PaymentsDbContext(DbContextOptions<PaymentsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("payments");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
