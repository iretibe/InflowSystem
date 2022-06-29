﻿using InflowSystem.Modules.Payments.Core.Withdrawals.Domain.Entities;
using InflowSystem.Modules.Payments.Core.Withdrawals.Domain.Repositories;
using InflowSystem.Modules.Payments.Core.Withdrawals.Events;
using InflowSystem.Modules.Payments.Core.Withdrawals.Exceptions;
using InflowSystem.Shared.Abstractions.Commands;
using InflowSystem.Shared.Abstractions.Events;
using InflowSystem.Shared.Abstractions.Messaging;
using InflowSystem.Shared.Abstractions.Time;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Commands.Handlers
{
    internal sealed class CompleteWithdrawalHandler : ICommandHandler<CompleteWithdrawal>
    {
        private readonly IWithdrawalRepository _withdrawalRepository;
        private readonly IClock _clock;
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<CompleteWithdrawalHandler> _logger;

        public CompleteWithdrawalHandler(IWithdrawalRepository withdrawalRepository, IClock clock,
            IMessageBroker messageBroker, ILogger<CompleteWithdrawalHandler> logger)
        {
            _withdrawalRepository = withdrawalRepository;
            _clock = clock;
            _messageBroker = messageBroker;
            _logger = logger;
        }

        public async Task HandleAsync(CompleteWithdrawal command, CancellationToken cancellationToken = default)
        {
            var withdrawal = await _withdrawalRepository.GetAsync(command.WithdrawalId);
            if (withdrawal is null)
            {
                throw new WithdrawalNotFoundException(command.WithdrawalId);
            }

            _logger.LogInformation($"Started processing a withdrawal with ID: '{command.WithdrawalId}'...");
            var (isCompleted, @event) = TryComplete(withdrawal, command.Secret);
            var now = _clock.CurrentDate();
            if (isCompleted)
            {
                withdrawal.Complete(now);
            }
            else
            {
                withdrawal.Reject(now);
            }

            await _withdrawalRepository.UpdateAsync(withdrawal);
            
            await _messageBroker.PublishAsync(@event, cancellationToken);
            
            _logger.LogInformation($"{(isCompleted ? "Completed" : "Rejected")} " +
                                   $"a withdrawal with ID: '{command.WithdrawalId}'.");
        }

        private static (bool isCompleted, IEvent @event) TryComplete(Withdrawal withdrawal, string secret)
        {
            // This could be refactored to an application service with checksum validation etc.
            return secret == "secret"
                ? (true, new WithdrawalCompleted(withdrawal.Id, withdrawal.Account.CustomerId,
                    withdrawal.Account.Currency, withdrawal.Amount))
                : (false, new WithdrawalRejected(withdrawal.Id, withdrawal.Account.CustomerId,
                    withdrawal.Account.Currency, withdrawal.Amount));
        }
    }
}
