using InflowSystem.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InflowSystem.Shared.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();

            //Implementation of Scrutor
            services.
                Scan(s => s.FromAssemblies(assemblies)
                    .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>))
                    .WithoutAttribute<DecoratorAttribute>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }
    }
}
