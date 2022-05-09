using InflowSystem.Shared.Abstractions.Commands;
using InflowSystem.Shared.Abstractions.Time;
using InflowSystem.Shared.Infrastructure.Commands;
using InflowSystem.Shared.Infrastructure.Postgres;
using InflowSystem.Shared.Infrastructure.SQLServer;
using InflowSystem.Shared.Infrastructure.Time;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Bootstrapper")]
namespace InflowSystem.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddModularInfrastructure(this IServiceCollection services)
        {
            services
                .AddCommands()
                .AddPostgres()
                //.AddSqlServer()
                .AddSingleton<IClock, UtcClock>();

            return services;
        }

        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : class, new()
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            
            return configuration.GetOptions<T>(sectionName);
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            configuration.GetSection(sectionName).Bind(options);

            return options;
        }
    }
}
