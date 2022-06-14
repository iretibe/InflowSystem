using InflowSystem.Shared.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InflowSystem.Shared.Infrastructure.Commands
{
    internal static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            services
                .AddSingleton<ICommandDispatcher, CommandDispatcher>();

            //Implementation of Scrutor
            services.
                Scan(s => s.FromAssemblies(assemblies)
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>))
                    .WithoutAttribute<DecoratorAttribute>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }
    }
}
