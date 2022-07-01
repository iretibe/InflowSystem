using InflowSystem.Modules.Payments.Core.DAL;
using InflowSystem.Modules.Payments.Core.DAL.Repositories;
using InflowSystem.Modules.Payments.Core.Deposits.Domain.Factories;
using InflowSystem.Modules.Payments.Core.Deposits.Domain.Repositories;
using InflowSystem.Modules.Payments.Core.Deposits.Domain.Services;
using InflowSystem.Modules.Payments.Core.Withdrawals.Domain.Repositories;
using InflowSystem.Modules.Payments.Core.Withdrawals.Services;
using InflowSystem.Modules.Payments.Shared.Clients;
using InflowSystem.Modules.Payments.Shared.Repositories;
using InflowSystem.Shared.Infrastructure.Messaging.Outbox;
using InflowSystem.Shared.Infrastructure.SQLServer;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Modules.Payments.Api")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Payments.Tests.Integration")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Payments.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace InflowSystem.Modules.Payments.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services
                .AddSingleton<ICustomerApiClient, CustomerApiClient>()
                .AddSingleton<IWithdrawalMetadataResolver, WithdrawalMetadataResolver>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IDepositRepository, DepositRepository>()
                .AddScoped<IDepositAccountRepository, DepositAccountRepository>()
                .AddScoped<IWithdrawalRepository, WithdrawalRepository>()
                .AddScoped<IWithdrawalAccountRepository, WithdrawalAccountRepository>()
                .AddSingleton<ICurrencyResolver, CurrencyResolver>()
                .AddSingleton<IDepositAccountFactory, DepositAccountFactory>()
                .AddSqlServer<PaymentsDbContext>()
                .AddOutbox<PaymentsDbContext>()
                .AddUnitOfWork<PaymentsUnitOfWork>();
        }
    }
}
