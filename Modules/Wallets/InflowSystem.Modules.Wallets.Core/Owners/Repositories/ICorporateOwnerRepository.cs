using InflowSystem.Modules.Wallets.Core.Owners.Entities;
using InflowSystem.Modules.Wallets.Core.Owners.Types;

namespace InflowSystem.Modules.Wallets.Core.Owners.Repositories
{
    internal interface ICorporateOwnerRepository
    {
        Task<CorporateOwner> GetAsync(OwnerId id);
        Task AddAsync(CorporateOwner owner);
        Task UpdateAsync(CorporateOwner owner);
    }
}
