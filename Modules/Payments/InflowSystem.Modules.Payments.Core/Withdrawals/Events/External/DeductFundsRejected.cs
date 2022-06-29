using InflowSystem.Shared.Abstractions.Events;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Events.External
{
    internal record DeductFundsRejected(Guid WalletId, Guid OwnerId, string Currency, 
        decimal Amount, string TransferName = null, string TransferMetadata = null) : IEvent;
}
