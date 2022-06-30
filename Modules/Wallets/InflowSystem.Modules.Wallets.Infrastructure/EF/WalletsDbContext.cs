using InflowSystem.Modules.Wallets.Core.Owners.Entities;
using InflowSystem.Modules.Wallets.Core.Wallets.Entities;
using InflowSystem.Shared.Infrastructure.Messaging.Outbox;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflowSystem.Modules.Wallets.Infrastructure.EF
{
    internal class WalletsDbContext : DbContext
    {
        public DbSet<InboxMessage> Inbox { get; set; }
        public DbSet<OutboxMessage> Outbox { get; set; }
        public DbSet<CorporateOwner> CorporateOwners { get; set; }
        public DbSet<IndividualOwner> IndividualOwners { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<IncomingTransfer> IncomingTransfers { get; set; }
        public DbSet<OutgoingTransfer> OutgoingTransfers { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public WalletsDbContext(DbContextOptions<WalletsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("wallets");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
