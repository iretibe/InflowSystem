using InflowSystem.Modules.Payments.Shared.Exceptions;
using InflowSystem.Modules.Payments.Shared.Repositories;
using InflowSystem.Shared.Abstractions.Events;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Modules.Payments.Core.Deposits.Events.External.Handlers
{
    internal sealed class CustomerUnlockedHandler : IEventHandler<CustomerUnlocked>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerUnlockedHandler> _logger;

        public CustomerUnlockedHandler(ICustomerRepository customerRepository,
            ILogger<CustomerUnlockedHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task HandleAsync(CustomerUnlocked @event, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepository.GetAsync(@event.CustomerId);
            if (customer is null)
            {
                throw new CustomerNotFoundException(@event.CustomerId);
            }

            customer.Unlock();

            await _customerRepository.UpdateAsync(customer);
        }
    }
}
