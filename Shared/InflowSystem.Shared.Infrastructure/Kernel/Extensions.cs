using InflowSystem.Shared.Abstractions.Kernel;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InflowSystem.Shared.Infrastructure.Kernel
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainEvents(this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
        {
            services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();

            services.Scan(s => s.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>))
                    .WithoutAttribute<DecoratorAttribute>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
