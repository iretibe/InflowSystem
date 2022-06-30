using InflowSystem.Modules.Wallets.Core.Owners.Entities;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InflowSystem.Modules.Wallets.Infrastructure.EF.Configurations
{
    internal class IndividualOwnerConfiguration : IEntityTypeConfiguration<IndividualOwner>
    {
        public void Configure(EntityTypeBuilder<IndividualOwner> builder)
        {
            builder.Property(x => x.FullName)
                .IsRequired()
                .HasConversion(x => x.Value, x => new FullName(x));
        }
    }
}
