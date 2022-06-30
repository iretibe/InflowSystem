using InflowSystem.Modules.Wallets.Core.Owners.Types;
using InflowSystem.Modules.Wallets.Core.Wallets.Entities;
using InflowSystem.Modules.Wallets.Core.Wallets.Types;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;

namespace InflowSystem.Modules.Wallets.Core.Wallets.Repositories
{
    internal interface IWalletRepository
    {
        Task<Wallet> GetAsync(WalletId id);
        Task<Wallet> GetAsync(OwnerId ownerId, Currency currency);
        Task AddAsync(Wallet wallet);
        Task UpdateAsync(Wallet wallet);
    }
}
