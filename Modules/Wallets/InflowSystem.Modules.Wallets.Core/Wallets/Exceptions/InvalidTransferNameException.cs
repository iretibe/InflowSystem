using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Wallets.Core.Wallets.Exceptions
{
    internal class InvalidTransferNameException : InflowException
    {
        public string Name { get; }

        public InvalidTransferNameException(string name) : base($"Transfer name: '{name}' is invalid.")
        {
            Name = name;
        }
    }
}
