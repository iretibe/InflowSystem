using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Commands
{
    internal record TransferFunds(Guid OwnerId, Guid OwnerWalletId, 
        Guid ReceiverWalletId, string Currency, decimal Amount) : ICommand;
}
