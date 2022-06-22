using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Shared.Infrastructure.Messaging.Dispatchers
{
    internal sealed class AsyncMessageDispatcher : IAsyncMessageDispatcher
    {
        private readonly IMessageChannel _channel;
        private readonly IMessageContextProvider _messageContextProvider;

        public AsyncMessageDispatcher(IMessageChannel channel, IMessageContextProvider messageContextProvider)
        {
            _channel = channel;
            _messageContextProvider = messageContextProvider;
        }

        public async Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken)
            where TMessage : class, IMessage
        {
            var messageContext = _messageContextProvider.Get(message);
            await _channel.Writer.WriteAsync(new MessageEnvelope(message, messageContext), cancellationToken);
        }
    }
}
