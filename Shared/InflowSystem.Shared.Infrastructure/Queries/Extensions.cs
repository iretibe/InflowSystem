using InflowSystem.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace InflowSystem.Shared.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            services
                .AddSingleton<IQueryDispatcher, QueryDispatcher>();

            //Implementation of Scrutor
            services.
                Scan(s => s.FromAssemblies(assemblies)
                    .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }
    }
}
