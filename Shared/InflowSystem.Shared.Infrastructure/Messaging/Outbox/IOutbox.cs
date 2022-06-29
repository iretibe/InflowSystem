﻿using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Shared.Infrastructure.Messaging.Outbox
{
    public interface IOutbox
    {
        bool Enabled { get; }
        Task SaveAsync(params IMessage[] messages);
        Task PublishUnsentAsync();
        Task CleanupAsync(DateTime? to = null);
    }
}
