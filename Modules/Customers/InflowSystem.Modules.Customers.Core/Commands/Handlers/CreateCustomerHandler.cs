using InflowSystem.Modules.Customers.Core.Clients;
using InflowSystem.Modules.Customers.Core.Domain.Entities;
using InflowSystem.Modules.Customers.Core.Domain.Repositories;
using InflowSystem.Modules.Customers.Core.Exceptions;
using InflowSystem.Shared.Abstractions.Commands;
using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;
using InflowSystem.Shared.Abstractions.Time;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Modules.Customers.Core.Commands.Handlers
{
    internal sealed class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserApiClient _userApiClient;
        private readonly IClock _clock;
        private readonly ILogger<CreateCustomerHandler> _logger;

        public CreateCustomerHandler(ICustomerRepository customerRepository,
            IUserApiClient userApiClient,
            IClock clock, ILogger<CreateCustomerHandler> logger)
        {
            _customerRepository = customerRepository;
            _userApiClient= userApiClient;
            _clock = clock;
            _logger = logger;
        }

        public async Task HandleAsync(CreateCustomer command, CancellationToken cancellationToken = default)
        {
            _ = new Email(command.Email);

            var user = await _userApiClient.GetAsync(command.Email);
            if (user is null)
            {
                throw new UserNotFoundException(command.Email);
            }

            if (user.Role is not "user")
            {
                return;
            }

            var customerId = user.UserId;
            if (await _customerRepository.GetAsync(customerId) is not null)
            {
                throw new CustomerAlreadyExistsException(customerId);
            }

            var customer = new Customer(Guid.NewGuid(), command.Email, _clock.CurrentDate());

            await _customerRepository.AddAsync(customer);

            _logger.LogInformation($"Created a customer with ID: '{customer.Id}'.");
        }
    }
}
