using InflowSystem.Modules.Users.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Bootstrapper")]
namespace InflowSystem.Modules.Users.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services)
        {
            services.AddCore();

            return services;
        }

        public static IApplicationBuilder UseUsersModule(this IApplicationBuilder builder)
        {
            return builder;
        }
    }
}
