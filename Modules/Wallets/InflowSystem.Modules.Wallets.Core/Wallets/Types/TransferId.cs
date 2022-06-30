using InflowSystem.Modules.Wallets.Core.Owners.Types;
using InflowSystem.Shared.Abstractions.Kernel.Types;

namespace InflowSystem.Modules.Wallets.Core.Wallets.Types
{
    internal class TransferId : TypeId
    {
        public TransferId() : this(Guid.NewGuid())
        {
        }

        public TransferId(Guid value) : base(value)
        {
        }

        public static implicit operator TransferId(Guid id) => new(id);

        public static implicit operator TransferId(OwnerId id) => id.Value;

        public override string ToString() => Value.ToString();
    }
}
