using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Api")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Infrastructure")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Tests.Contract")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Tests.EndToEnd")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Tests.Integration")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
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
