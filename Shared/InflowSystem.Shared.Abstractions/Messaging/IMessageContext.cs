using InflowSystem.Shared.Abstractions.Contexts;

namespace InflowSystem.Shared.Abstractions.Messaging
{
    public interface IMessageContext
    {
        public Guid MessageId { get; }
        public IContext Context { get; }
    }
}
