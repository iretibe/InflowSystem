using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Shared.Infrastructure.Messaging.Contexts
{
    public interface IMessageContextRegistry
    {
        void Set(IMessage message, IMessageContext context);
    }
}
