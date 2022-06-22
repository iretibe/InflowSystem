using InflowSystem.Shared.Abstractions.Messaging;
using InflowSystem.Shared.Abstractions.Modules;
using InflowSystem.Shared.Infrastructure.Messaging.Dispatchers;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Shared.Infrastructure.Messaging.Brokers
{
    internal sealed class InMemoryMessageBroker : IMessageBroker
    {
        private readonly IModuleClient _moduleClient;
        private readonly IAsyncMessageDispatcher _asyncMessageDispatcher;
        private readonly MessagingOptions _messagingOptions;
        private readonly ILogger<InMemoryMessageBroker> _logger;

        public InMemoryMessageBroker(IModuleClient moduleClient, IAsyncMessageDispatcher asyncMessageDispatcher, 
            MessagingOptions messagingOptions, ILogger<InMemoryMessageBroker> logger)
        {
            _moduleClient = moduleClient;
            _asyncMessageDispatcher = asyncMessageDispatcher;
            _messagingOptions = messagingOptions;
            _logger = logger;
        }

        public Task PublishAsync(IMessage message, CancellationToken cancellationToken = default)
            => PublishAsync(cancellationToken, message);

        public Task PublishAsync(IMessage[] messages, CancellationToken cancellationToken = default)
            => PublishAsync(cancellationToken, messages);

        private async Task PublishAsync(CancellationToken cancellationToken, params IMessage[] messages)
        {
            if (messages is null)
            {
                return;
            }

            messages = messages.Where(x => x is not null).ToArray();
            if (!messages.Any())
            {
                return;
            }

            var tasks = 
                _messagingOptions.UseAsyncDispatcher ?
                messages.Select(x => _asyncMessageDispatcher.PublishAsync(x, cancellationToken)) : 
                messages.Select(x => _moduleClient.PublishAsync(x, cancellationToken));

            await Task.WhenAll(tasks);
        }
    }
}
