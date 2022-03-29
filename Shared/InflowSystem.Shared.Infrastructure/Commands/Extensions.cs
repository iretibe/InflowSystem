using InflowSystem.Shared.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace InflowSystem.Shared.Infrastructure.Commands
{
    internal static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            services
                .AddSingleton<ICommandDispatcher, CommandDispatcher>();

            //Implementation of Scrutor
            services.
                Scan(s => s.FromAssemblies(assemblies)
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }
    }
}
