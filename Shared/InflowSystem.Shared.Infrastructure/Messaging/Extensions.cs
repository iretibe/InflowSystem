using InflowSystem.Shared.Abstractions.Messaging;
using InflowSystem.Shared.Infrastructure.Messaging.Brokers;
using InflowSystem.Shared.Infrastructure.Messaging.Contexts;
using InflowSystem.Shared.Infrastructure.Messaging.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace InflowSystem.Shared.Infrastructure.Messaging
{
    internal static class Extensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddTransient<IMessageBroker, InMemoryMessageBroker>();
            services.AddTransient<IMessageChannel, MessageChannel>();
            services.AddTransient<IAsyncMessageDispatcher, AsyncMessageDispatcher>();
            services.AddSingleton<IMessageContextProvider, MessageContextProvider>();

            var messagingOptions = services.GetOptions<MessagingOptions>("messaging");
            services.AddSingleton(messagingOptions);

            if (messagingOptions.UseAsyncDispatcher)
            {
                services.AddHostedService<AsyncDispatcherJob>();
            }

            return services;
        }
    }
}
