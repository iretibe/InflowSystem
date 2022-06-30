using InflowSystem.Modules.Wallets.Application.Wallets.Events;
using InflowSystem.Modules.Wallets.Core.Wallets.Exceptions;
using InflowSystem.Modules.Wallets.Core.Wallets.Repositories;
using InflowSystem.Shared.Abstractions.Commands;
using InflowSystem.Shared.Abstractions.Messaging;
using InflowSystem.Shared.Abstractions.Time;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Modules.Wallets.Application.Wallets.Commands.Handlers
{
    internal sealed class AddFundsHandler : ICommandHandler<AddFunds>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IClock _clock;
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<AddFundsHandler> _logger;

        public AddFundsHandler(IWalletRepository walletRepository, IClock clock, 
            IMessageBroker messageBroker, ILogger<AddFundsHandler> logger)
        {
            _walletRepository = walletRepository;
            _clock = clock;
            _messageBroker = messageBroker;
            _logger = logger;
        }

        public async Task HandleAsync(AddFunds command, CancellationToken cancellationToken = default)
        {
            var wallet = await _walletRepository.GetAsync(command.WalletId);
            if (wallet is null)
            {
                throw new WalletNotFoundException(command.WalletId);
            }

            if (wallet.Currency != command.Currency)
            {
                throw new InvalidTransferCurrencyException(command.Currency);
            }

            var transfer = wallet.AddFunds(command.TransferId, command.Amount, _clock.CurrentDate(),
                command.TransferName, command.TransferMetadata);

            await _walletRepository.UpdateAsync(wallet);

            await _messageBroker.PublishAsync(new FundsAdded(wallet.Id, wallet.OwnerId, wallet.Currency,
                transfer.Amount, transfer.Name, transfer.Metadata), cancellationToken);

            _logger.LogInformation($"Added {transfer.Amount} {transfer.Currency} to wallet with ID: '{wallet.Id}'.");
        }
    }
}
