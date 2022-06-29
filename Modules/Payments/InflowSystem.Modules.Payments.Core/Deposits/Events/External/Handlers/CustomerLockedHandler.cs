using InflowSystem.Modules.Payments.Shared.Exceptions;
using InflowSystem.Modules.Payments.Shared.Repositories;
using InflowSystem.Shared.Abstractions.Events;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Modules.Payments.Core.Deposits.Events.External.Handlers
{
    internal sealed class CustomerLockedHandler : IEventHandler<CustomerLocked>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerLockedHandler> _logger;

        public CustomerLockedHandler(ICustomerRepository customerRepository,
            ILogger<CustomerLockedHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task HandleAsync(CustomerLocked @event, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepository.GetAsync(@event.CustomerId);
            if (customer is null)
            {
                throw new CustomerNotFoundException(@event.CustomerId);
            }

            customer.Lock();

            await _customerRepository.UpdateAsync(customer);
        }
    }
}
