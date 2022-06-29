﻿using Humanizer;
using InflowSystem.Shared.Abstractions.Events;
using InflowSystem.Shared.Abstractions.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace InflowSystem.Shared.Infrastructure.Messaging.Outbox
{
    [Decorator]
    internal sealed class InboxEventHandlerDecorator<T> : IEventHandler<T> where T : class, IEvent
    {
        private readonly IEventHandler<T> _handler;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageContextProvider _messageContextProvider;
        private readonly InboxTypeRegistry _inboxTypeRegistry;
        private readonly bool _enabled;

        public InboxEventHandlerDecorator(IEventHandler<T> handler, IServiceProvider serviceProvider,
            IMessageContextProvider messageContextProvider, InboxTypeRegistry inboxTypeRegistry, OutboxOptions options)
        {
            _handler = handler;
            _serviceProvider = serviceProvider;
            _messageContextProvider = messageContextProvider;
            _inboxTypeRegistry = inboxTypeRegistry;
            _enabled = options.Enabled;
        }

        public async Task HandleAsync(T @event, CancellationToken cancellationToken = default)
        {
            if (_enabled)
            {
                var inboxType = _inboxTypeRegistry.Resolve<T>();
                if (inboxType is null)
                {
                    await _handler.HandleAsync(@event, cancellationToken);
                    return;
                }

                using var scope = _serviceProvider.CreateScope();
                var inbox = (IInbox)_serviceProvider.GetRequiredService(inboxType);
                var context = _messageContextProvider.Get(@event);
                var name = @event.GetType().Name.Underscore();
                await inbox.HandleAsync(context.MessageId, name, () => _handler.HandleAsync(@event, cancellationToken));
                return;
            }

            await _handler.HandleAsync(@event, cancellationToken);
        }
    }
}
