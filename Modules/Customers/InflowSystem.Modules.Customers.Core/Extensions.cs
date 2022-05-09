using InflowSystem.Modules.Customers.Core.DAL;
using InflowSystem.Modules.Customers.Core.DAL.Repositories;
using InflowSystem.Modules.Customers.Core.Domain.Repositories;
using InflowSystem.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Modules.Customers.Api")]
namespace InflowSystem.Modules.Customers.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddPostgres<CustomersDbContext>();

            return services;
        }
    }
}
