﻿using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Shared.Infrastructure.Messaging.Dispatchers
{
    public interface IAsyncMessageDispatcher
    {
        Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
           where TMessage : class, IMessage;
    }
}
