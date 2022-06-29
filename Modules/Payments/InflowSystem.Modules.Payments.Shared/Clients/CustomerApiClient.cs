using InflowSystem.Modules.Payments.Shared.Clients.DTO;
using InflowSystem.Shared.Abstractions.Modules;

namespace InflowSystem.Modules.Payments.Shared.Clients
{
    internal class CustomerApiClient : ICustomerApiClient
    {
        private readonly IModuleClient _moduleClient;

        public CustomerApiClient(IModuleClient moduleClient)
        {
            _moduleClient = moduleClient;
        }

        public Task<CustomerDto> GetAsync(Guid customerId)
            => _moduleClient.SendAsync<CustomerDto>("customers/get", new { customerId });
    }
}
