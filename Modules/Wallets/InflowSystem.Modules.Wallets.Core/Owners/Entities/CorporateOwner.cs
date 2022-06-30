using InflowSystem.Modules.Wallets.Core.Owners.Types;
using InflowSystem.Modules.Wallets.Core.Owners.ValueObjects;

namespace InflowSystem.Modules.Wallets.Core.Owners.Entities
{
    internal class CorporateOwner : Owner
    {
        public TaxId TaxId { get; private set; }

        private CorporateOwner()
        {
        }

        public CorporateOwner(OwnerId id, OwnerName name, TaxId taxId, DateTime createdAt) : base(id, name, createdAt)
        {
            TaxId = taxId;
        }
    }
}
