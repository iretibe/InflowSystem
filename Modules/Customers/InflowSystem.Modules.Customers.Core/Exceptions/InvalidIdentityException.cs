using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Customers.Core.Exceptions
{
    internal class InvalidIdentityException : InflowException
    {
        public string Type { get; }

        public InvalidIdentityException(string type, string series)
            : base($"Identity type: '{type}', series: '{series}' is invalid.")
        {
            Type = type;
        }
    }
}
