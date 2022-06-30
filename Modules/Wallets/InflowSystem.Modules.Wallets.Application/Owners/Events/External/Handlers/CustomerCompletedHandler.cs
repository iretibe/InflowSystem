using InflowSystem.Modules.Wallets.Core.Owners.Entities;
using InflowSystem.Modules.Wallets.Core.Owners.Repositories;
using InflowSystem.Shared.Abstractions.Events;
using InflowSystem.Shared.Abstractions.Time;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Modules.Wallets.Application.Owners.Events.External.Handlers
{
    internal sealed class CustomerCompletedHandler : IEventHandler<CustomerCompleted>
    {
        private readonly IIndividualOwnerRepository _ownerRepository;
        private readonly IClock _clock;
        private readonly ILogger<CustomerCompletedHandler> _logger;

        public CustomerCompletedHandler(IIndividualOwnerRepository ownerRepository, 
            IClock clock, ILogger<CustomerCompletedHandler> logger)
        {
            _ownerRepository = ownerRepository;
            _clock = clock;
            _logger = logger;
        }

        public async Task HandleAsync(CustomerCompleted @event, CancellationToken cancellationToken = default)
        {
            var owner = new IndividualOwner(@event.CustomerId, @event.Name, @event.FullName, _clock.CurrentDate());
            
            await _ownerRepository.AddAsync(owner);
            
            _logger.LogInformation($"Created individual owner with ID: '{owner.Id}' based on customer.");
        }
    }
}
