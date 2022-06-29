﻿namespace InflowSystem.Shared.Infrastructure.Serialization
{
    internal interface IJsonSerializer
    {
        string Serialize<T>(T value);
        T Deserialize<T>(string value);
        object Deserialize(string value, Type type);
    }
}
