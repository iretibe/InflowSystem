using InflowSystem.Modules.Users.Core;
using InflowSystem.Modules.Users.Core.DTO;
using InflowSystem.Modules.Users.Core.Queries;
using InflowSystem.Shared.Abstractions.Modules;
using InflowSystem.Shared.Abstractions.Queries;
using InflowSystem.Shared.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InflowSystem.Modules.Users.Api
{
    internal class UsersModule : IModule
    {
        public string Name { get; } = "Users";

        public IEnumerable<string> Policies { get; } = new[]
        {
            "users"
        };

        public void Register(IServiceCollection services)
        {
            services.AddCore();
        }

        public void Use(IApplicationBuilder app)
        {
            app.UseModuleRequests()
            .Subscribe<GetUserByEmail, UserDetailsDto>("users/get",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken));
        }
    }
}
