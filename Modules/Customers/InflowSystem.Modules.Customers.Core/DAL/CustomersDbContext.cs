﻿using InflowSystem.Modules.Customers.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Modules.Customers.Core.DAL
{
    internal class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("customers");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
