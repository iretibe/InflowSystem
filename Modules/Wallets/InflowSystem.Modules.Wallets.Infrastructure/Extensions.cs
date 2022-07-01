using InflowSystem.Modules.Wallets.Application.Wallets.Storage;
using InflowSystem.Modules.Wallets.Core.Owners.Repositories;
using InflowSystem.Modules.Wallets.Core.Wallets.Repositories;
using InflowSystem.Modules.Wallets.Infrastructure.EF;
using InflowSystem.Modules.Wallets.Infrastructure.EF.Repositories;
using InflowSystem.Modules.Wallets.Infrastructure.Storage;
using InflowSystem.Shared.Infrastructure.Messaging.Outbox;
using InflowSystem.Shared.Infrastructure.SQLServer;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Api")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Tests.Contract")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Tests.EndToEnd")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Tests.Integration")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Wallets.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace InflowSystem.Modules.Wallets.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                .AddScoped<ITransferStorage, TransferStorage>()
                .AddScoped<IWalletStorage, WalletStorage>()
                .AddScoped<ICorporateOwnerRepository, CorporateOwnerRepository>()
                .AddScoped<IIndividualOwnerRepository, IndividualOwnerRepository>()
                .AddScoped<IWalletRepository, WalletRepository>()
                .AddSqlServer<WalletsDbContext>()
                .AddOutbox<WalletsDbContext>()
                .AddUnitOfWork<WalletsUnitOfWork>();
        }
    }
}
