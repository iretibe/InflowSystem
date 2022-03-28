using InflowSystem.Modules.Customers.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Bootstrapper")]
namespace InflowSystem.Modules.Customers.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddCustomersModule(this IServiceCollection services)
        {
            services.AddCore();

            return services;
        }

        public static IApplicationBuilder UseCustomersModule(this IApplicationBuilder builder)
        {
            return builder;
        }
    }
}
