using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Shared.Infrastructure.Messaging.Dispatchers
{
    internal record MessageEnvelope(IMessage Message, IMessageContext MessageContext);
}
