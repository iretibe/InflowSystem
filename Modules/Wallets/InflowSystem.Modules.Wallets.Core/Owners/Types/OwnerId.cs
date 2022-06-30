using InflowSystem.Shared.Abstractions.Kernel.Types;

namespace InflowSystem.Modules.Wallets.Core.Owners.Types
{
    internal class OwnerId : TypeId
    {
        public OwnerId(Guid value) : base(value)
        {
        }

        public static implicit operator OwnerId(Guid id) => new(id);

        public static implicit operator Guid(OwnerId id) => id.Value;
    }
}
