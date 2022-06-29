using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Shared.Infrastructure.Messaging.Outbox
{
    public interface IOutboxBroker
    {
        bool Enabled { get; }
        Task SendAsync(params IMessage[] messages);
    }
}
