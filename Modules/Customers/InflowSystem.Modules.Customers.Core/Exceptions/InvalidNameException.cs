using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Customers.Core.Exceptions
{
    internal class InvalidNameException : InflowException
    {
        public string Name { get; }

        public InvalidNameException(string name) : base($"Name: '{name}' is invalid.")
        {
            Name = name;
        }
    }
}
