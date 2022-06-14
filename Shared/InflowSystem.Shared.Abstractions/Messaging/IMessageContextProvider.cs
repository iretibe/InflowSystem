﻿namespace InflowSystem.Shared.Abstractions.Messaging
{
    public interface IMessageContextProvider
    {
        IMessageContext Get(IMessage message);
    }
}
