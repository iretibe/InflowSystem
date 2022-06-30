using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Wallets.Core.Wallets.Exceptions
{
    internal class InvalidTransferMetadataException : InflowException
    {
        public string Metadata { get; }

        public InvalidTransferMetadataException(string metadata) : base($"Transfer metadata: '{metadata}' is invalid.")
        {
            Metadata = metadata;
        }
    }
}
