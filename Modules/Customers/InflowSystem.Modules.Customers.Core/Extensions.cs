using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Modules.Customers.Api")]
namespace InflowSystem.Modules.Customers.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services;
        }
    }
}
