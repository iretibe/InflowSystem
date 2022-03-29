using InflowSystem.Shared.Abstractions.Commands;
using InflowSystem.Shared.Abstractions.Time;
using InflowSystem.Shared.Infrastructure.Commands;
using InflowSystem.Shared.Infrastructure.Time;
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
                //.AddSingleton<ICommandDispatcher, CommandDispatcher>()
                .AddSingleton<IClock, UtcClock>();

            return services;
        }
    }
}
