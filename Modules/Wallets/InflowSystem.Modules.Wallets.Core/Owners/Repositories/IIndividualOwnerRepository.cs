using InflowSystem.Modules.Wallets.Core.Owners.Entities;
using InflowSystem.Modules.Wallets.Core.Owners.Types;

namespace InflowSystem.Modules.Wallets.Core.Owners.Repositories
{
    internal interface IIndividualOwnerRepository
    {
        Task<IndividualOwner> GetAsync(OwnerId id);
        Task AddAsync(IndividualOwner owner);
        Task UpdateAsync(IndividualOwner owner);
    }
}
