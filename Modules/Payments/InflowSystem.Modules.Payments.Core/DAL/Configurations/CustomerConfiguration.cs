using InflowSystem.Modules.Payments.Shared.Entities;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InflowSystem.Modules.Payments.Core.DAL.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(100)
                .HasConversion(x => x.Value, x => new FullName(x));

            builder.Property(x => x.Nationality).HasMaxLength(2)
                .HasConversion(x => x.Value, x => new Nationality(x));
        }
    }
}
