using InflowSystem.Shared.Abstractions.Modules;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Shared.Infrastructure.Messaging.Dispatchers
{
    internal sealed class AsyncDispatcherJob : BackgroundService
    {
        private readonly IMessageChannel _messageChannel;
        private readonly IModuleClient _moduleClient;
        private readonly ILogger<AsyncDispatcherJob> _logger;

        public AsyncDispatcherJob(IMessageChannel messageChannel, IModuleClient moduleClient,
            ILogger<AsyncDispatcherJob> logger)
        {
            _messageChannel = messageChannel;
            _moduleClient = moduleClient;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var envelope in _messageChannel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    await _moduleClient.PublishAsync(envelope.Message, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }

            //_logger.LogInformation("Finished running the async dispatcher.");
        }
    }
}
