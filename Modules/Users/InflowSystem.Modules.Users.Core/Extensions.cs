using InflowSystem.Modules.Users.Core.DAL;
using InflowSystem.Modules.Users.Core.DAL.Repositories;
using InflowSystem.Modules.Users.Core.Entities;
using InflowSystem.Modules.Users.Core.Repositories;
using InflowSystem.Modules.Users.Core.Services;
using InflowSystem.Shared.Infrastructure;
using InflowSystem.Shared.Infrastructure.SQLServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Modules.Users.Api")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Users.Tests.Integration")]
[assembly: InternalsVisibleTo("InflowSystem.Modules.Users.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace InflowSystem.Modules.Users.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            var registrationOptions = services.GetOptions<RegistrationOptions>("users:registration");
            services.AddSingleton(registrationOptions);

            return services
                .AddSingleton<IUserRequestStorage, UserRequestStorage>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddSqlServer<UsersDbContext>()
                .AddOutbox<UsersDbContext>()
                .AddUnitOfWork<UsersUnitOfWork>()
                .AddInitializer<UsersInitializer>();
        }
    }
}
