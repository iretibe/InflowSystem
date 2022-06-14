using InflowSystem.Shared.Abstractions.Commands;
using InflowSystem.Shared.Abstractions.Events;
using InflowSystem.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace InflowSystem.Shared.Infrastructure.Modules
{
    public static class Extensions
    {
        public static IHostBuilder ConfigureModules(this IHostBuilder builder)
            => builder.ConfigureAppConfiguration((ctx, cfg) =>
            {
                foreach (var settings in GetSettings("*"))
                {
                    cfg.AddJsonFile(settings);
                }

                //foreach (var settings in GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}"))
                //{
                //    cfg.AddJsonFile(settings);
                //}

                IEnumerable<string> GetSettings(string pattern)
                    => Directory.EnumerateFiles(ctx.HostingEnvironment.ContentRootPath,
                        $"module.{pattern}.json", SearchOption.AllDirectories);
            });

        public static IServiceCollection AddModuleRequests(this IServiceCollection services, 
            IEnumerable<Assembly> assemblies)
        {
            services.AddModuleRegistry(assemblies);
                        
            services.AddSingleton<IModuleSubscriber, ModuleSubscriber>();
            services.AddSingleton<IModuleClient, ModuleClient>();
            services.AddSingleton<IModuleSerializer, JsonModuleSerializer>();

            return services;
        }

        public static IModuleSubscriber UseModuleRequests(this IApplicationBuilder app)
            => app.ApplicationServices.GetRequiredService<IModuleSubscriber>();

        private static void AddModuleRegistry(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            var registry = new ModuleRegistry();
            var types = assemblies.SelectMany(x => x.GetTypes()).ToArray();

            var commandTypes = types
                .Where(t => t.IsClass && typeof(ICommand).IsAssignableFrom(t))
                .ToArray();

            var eventTypes = types
                .Where(x => x.IsClass && typeof(IEvent).IsAssignableFrom(x))
                .ToArray();

            services.AddSingleton<IModuleRegistry>(sp =>
            {
                var commandDispatcher = sp.GetRequiredService<ICommandDispatcher>();
                var commandDispatcherType = commandDispatcher.GetType();

                var eventDispatcher = sp.GetRequiredService<IEventDispatcher>();
                var eventDispatcherType = eventDispatcher.GetType();

                foreach (var type in commandTypes)
                {
                    registry.AddBroadcastAction(type, (@event, cancellationToken) =>
                        (Task)commandDispatcherType.GetMethod(nameof(commandDispatcher.SendAsync))
                            ?.MakeGenericMethod(type)
                            .Invoke(commandDispatcher, new[] { @event, cancellationToken }));
                }

                foreach (var type in eventTypes)
                {
                    registry.AddBroadcastAction(type, (@event, cancellationToken) =>
                        (Task)eventDispatcherType.GetMethod(nameof(eventDispatcher.PublishAsync))
                            ?.MakeGenericMethod(type)
                            .Invoke(eventDispatcher, new[] { @event, cancellationToken }));
                }

                return registry;
            });
        }
    }
}
