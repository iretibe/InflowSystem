using InflowSystem.Shared.Abstractions.Dispatchers;
using InflowSystem.Shared.Abstractions.Modules;
using InflowSystem.Shared.Abstractions.Storage;
using InflowSystem.Shared.Abstractions.Time;
using InflowSystem.Shared.Infrastructure.Api;
using InflowSystem.Shared.Infrastructure.Auth;
using InflowSystem.Shared.Infrastructure.Commands;
using InflowSystem.Shared.Infrastructure.Contexts;
using InflowSystem.Shared.Infrastructure.Contracts;
using InflowSystem.Shared.Infrastructure.Dispatchers;
using InflowSystem.Shared.Infrastructure.Events;
using InflowSystem.Shared.Infrastructure.Exceptions;
using InflowSystem.Shared.Infrastructure.Kernel;
using InflowSystem.Shared.Infrastructure.Logging;
using InflowSystem.Shared.Infrastructure.Messaging;
using InflowSystem.Shared.Infrastructure.Messaging.Outbox;
using InflowSystem.Shared.Infrastructure.Modules;
using InflowSystem.Shared.Infrastructure.Queries;
using InflowSystem.Shared.Infrastructure.Security;
using InflowSystem.Shared.Infrastructure.Serialization;
using InflowSystem.Shared.Infrastructure.SQLServer;
using InflowSystem.Shared.Infrastructure.Storage;
using InflowSystem.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Bootstrapper")]
namespace InflowSystem.Shared.Infrastructure
{
    public static class Extensions
    {
        private const string CorrelationIdKey = "correlation-id";

        public static IServiceCollection AddInitializer<T>(this IServiceCollection services) where T : class, IInitializer
            => services.AddTransient<IInitializer, T>();

        public static IServiceCollection AddModularInfrastructure(this IServiceCollection services,
            IList<Assembly> assemblies, IList<IModule> modules)
        {
            var disabledModules = new List<string>();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                foreach (var (key, value) in configuration.AsEnumerable())
                {
                    if (!key.Contains(":module:enabled"))
                    {
                        continue;
                    }

                    if (!bool.Parse(value))
                    {
                        disabledModules.Add(key.Split(":")[0]);
                    }
                }
            }

            services
                .AddCorsPolicy()
                //.AddSwaggerGen(swagger =>
                //{
                //    swagger.EnableAnnotations();
                //    swagger.CustomSchemaIds(x => x.FullName);
                //    swagger.SwaggerDoc("v1", new OpenApiInfo
                //    {
                //        Title = "Modular API",
                //        Version = "v1"
                //    });
                //})
                ;

            var appOptions = services.GetOptions<AppOptions>("app");
            services.AddSingleton(appOptions);

            services
                .AddMemoryCache()
                .AddHttpClient()
                .AddSingleton<IRequestStorage, RequestStorage>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddSingleton<IJsonSerializer, SystemTextJsonSerializer>()
                .AddModuleInfo(modules)
                .AddModuleRequests(assemblies)
                .AddAuth(modules)
                .AddErrorHandling()
                .AddContext()
                .AddCommands(assemblies)
                .AddQueries(assemblies)
                .AddEvents(assemblies)
                .AddDomainEvents(assemblies)
                .AddMessaging()
                .AddSecurity()
                .AddSingleton<IClock, UtcClock>()
                .AddSingleton<IDispatcher, InMemoryDispatcher>()
                .AddLoggingDecorators()
                //.AddPostgres()
                .AddSqlServer()
                .AddOutbox()
                .AddHostedService<DbContextAppInitializer>()
                .AddContracts()
                .AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    var removedParts = new List<ApplicationPart>();
                    foreach (var disabledModule in disabledModules)
                    {
                        var parts = manager.ApplicationParts.Where(x => x.Name.Contains(disabledModule,
                            StringComparison.InvariantCultureIgnoreCase));
                        removedParts.AddRange(parts);
                    }

                    foreach (var part in removedParts)
                    {
                        manager.ApplicationParts.Remove(part);
                    }

                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            return services;
        }

        public static IApplicationBuilder UseModularInfrastructure(this IApplicationBuilder app)
        {
            app
                .UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.All
                })
                .UseCors("cors")
                .UseCorrelationId()
                .UseErrorHandling()
                .UseSwagger()
                .UseReDoc(reDoc =>
                {
                    reDoc.RoutePrefix = "docs";
                    reDoc.SpecUrl("/swagger/v1/swagger.json");
                    reDoc.DocumentTitle = "Modular API";
                })
                .UseAuth()
                .UseContext()
                .UseLogging()
                .UseRouting()
                .UseAuthorization();

            return app;
        }

        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : class, new()
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            
            return configuration.GetOptions<T>(sectionName);
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            configuration.GetSection(sectionName).Bind(options);

            return options;
        }

        public static string GetModuleName(this object value)
        => value?.GetType().GetModuleName() ?? string.Empty;

        public static string GetModuleName(this Type type, string namespacePart = "Modules", int splitIndex = 2)
        {
            if (type?.Namespace is null)
            {
                return string.Empty;
            }

            return type.Namespace.Contains(namespacePart)
                ? type.Namespace.Split(".")[splitIndex].ToLowerInvariant()
                : string.Empty;
        }

        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        => app.Use((ctx, next) =>
        {
            ctx.Items.Add(CorrelationIdKey, Guid.NewGuid());
            return next();
        });

        public static Guid? TryGetCorrelationId(this HttpContext context)
            => context.Items.TryGetValue(CorrelationIdKey, out var id) ? (Guid)id : null;
    }
}
