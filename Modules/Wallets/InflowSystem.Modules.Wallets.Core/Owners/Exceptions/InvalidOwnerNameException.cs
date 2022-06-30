using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Wallets.Core.Owners.Exceptions
{
    internal class InvalidOwnerNameException : InflowException
    {
        public string Name { get; }

        public InvalidOwnerNameException(string name) : base($"Owner name: '{name}' is invalid.")
        {
            Name = name;
        }
    }
}
