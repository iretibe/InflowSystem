using System.Threading.Channels;

namespace InflowSystem.Shared.Infrastructure.Messaging.Dispatchers
{
    internal interface IMessageChannel
    {
        ChannelReader<MessageEnvelope> Reader { get; }
        ChannelWriter<MessageEnvelope> Writer { get; }
    }
}
