using InflowSystem.Modules.Customers.Core.Domain.Entities;
using InflowSystem.Modules.Customers.Core.Domain.Repositories;
using InflowSystem.Shared.Abstractions.Commands;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;
using InflowSystem.Shared.Abstractions.Time;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Modules.Customers.Core.Commands.Handlers
{
    internal sealed class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IClock _clock;
        private readonly ILogger<CreateCustomerHandler> _logger;

        public CreateCustomerHandler(ICustomerRepository customerRepository,
            IClock clock, ILogger<CreateCustomerHandler> logger)
        {
            _customerRepository = customerRepository;
            _clock = clock;
            _logger = logger;
        }

        public async Task HandleAsync(CreateCustomer command, CancellationToken cancellationToken = default)
        {
            _ = new Email(command.Email);

            var customer = new Customer(Guid.NewGuid(), command.Email, _clock.CurrentDate());

            await _customerRepository.AddAsync(customer);

            _logger.LogInformation($"Created a customer with ID: '{customer.Id}'.");
        }
    }
}
