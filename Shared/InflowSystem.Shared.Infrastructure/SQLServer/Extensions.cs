using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InflowSystem.Shared.Infrastructure.SQLServer
{
    public static class Extensions
    {
        internal static IServiceCollection AddSqlServer(this IServiceCollection services)
        {
            var options = services.GetOptions<SQLServerOptions>(sectionName: "sql");
            services.AddSingleton(options);
            services.AddHostedService<DbContextAppInitializer>();

            return services;
        }

        public static IServiceCollection AddSqlServer<T>(this IServiceCollection services) where T : DbContext
        {
            var options = services.GetOptions<SQLServerOptions>(sectionName: "sql");
            services.AddDbContext<T>(x => x.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
