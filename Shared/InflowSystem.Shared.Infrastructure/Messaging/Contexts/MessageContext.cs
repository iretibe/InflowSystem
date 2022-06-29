using InflowSystem.Shared.Abstractions.Contexts;
using InflowSystem.Shared.Abstractions.Messaging;

namespace InflowSystem.Shared.Infrastructure.Messaging.Contexts
{
    public class MessageContext : IMessageContext
    {
        public Guid MessageId { get; }
        public IContext Context { get; }

        public MessageContext(Guid messageId, IContext context)
        {
            MessageId = messageId;
            Context = context;
        }
    }
}
