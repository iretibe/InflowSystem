using InflowSystem.Modules.Wallets.Core.Wallets.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InflowSystem.Modules.Wallets.Infrastructure.EF.Configurations
{
    internal class OutgoingTransferConfiguration : IEntityTypeConfiguration<OutgoingTransfer>
    {
        public void Configure(EntityTypeBuilder<OutgoingTransfer> builder)
        {
        }
    }
}
