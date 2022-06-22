using InflowSystem.Modules.Customers.Api.Controllers;
using InflowSystem.Modules.Customers.Core;
using InflowSystem.Modules.Customers.Core.DTO;
using InflowSystem.Shared.Abstractions.Modules;
using InflowSystem.Shared.Abstractions.Queries;
using InflowSystem.Shared.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InflowSystem.Modules.Customers.Api
{
    internal class CustomersModule : IModule
    {
        public string Name { get; } = "Customers";

        public IEnumerable<string> Policies { get; } = new[]
        {
            "customers"
        };

        public void Register(IServiceCollection services)
        {
            services.AddCore();
        }

        public void Use(IApplicationBuilder app)
        {
            app.UseModuleRequests()
                .Subscribe<GetCustomer, CustomerDetailDto>("customers/get",
                    (query, serviceProvider, cancellationToken)
                        => serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken));

            app.UseContracts()
                .Register<SignedUpContract>()
                .Register<UserStateUpdatedContract>();
        }
    }
}
