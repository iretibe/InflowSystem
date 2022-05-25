﻿using InflowSystem.Modules.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Modules.Users.Core.DAL
{
    internal class UsersDbContext : DbContext
    {
        //public DbSet<InboxMessage> Inbox { get; set; }
        //public DbSet<OutboxMessage> Outbox { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("users");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
