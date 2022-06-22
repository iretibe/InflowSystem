﻿using InflowSystem.Modules.Customers.Core.Domain.Entities;
using InflowSystem.Modules.Customers.Core.Domain.Repositories;
using InflowSystem.Shared.Abstractions.Events;
using InflowSystem.Shared.Abstractions.Messaging;
using InflowSystem.Shared.Abstractions.Time;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Modules.Customers.Core.Events.External.Handlers
{
    internal sealed class SignedUpHandler : IEventHandler<SignedUp>
    {
        private const string ValidRole = "user";
        private readonly ICustomerRepository _customerRepository;
        private readonly IMessageBroker _messageBroker;
        private readonly IClock _clock;
        private readonly ILogger<SignedUpHandler> _logger;

        public SignedUpHandler(ICustomerRepository customerRepository, 
            IMessageBroker messageBroker, IClock clock, ILogger<SignedUpHandler> logger)
        {
            _customerRepository = customerRepository;
            _messageBroker = messageBroker;
            _clock = clock;
            _logger = logger;
        }

        public async Task HandleAsync(SignedUp @event, CancellationToken cancellationToken = default)
        {
            if (@event.Role is not ValidRole)
            {
                return;
            }

            var customer = new Customer(@event.UserId, @event.Email, _clock.CurrentDate());

            await _customerRepository.AddAsync(customer);

            _logger.LogInformation($"Created a new customer based on user with ID: '{@event.UserId}'.");

            await _messageBroker.PublishAsync(new CustomerCreated(customer.Id), cancellationToken);
        }
    }
}
