using Microsoft.Extensions.DependencyInjection;

namespace InflowSystem.Modules.Wallets.Application
{
    internal static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
