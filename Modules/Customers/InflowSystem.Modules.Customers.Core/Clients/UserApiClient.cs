using InflowSystem.Modules.Customers.Core.Clients.DTO;
using InflowSystem.Shared.Abstractions.Modules;

namespace InflowSystem.Modules.Customers.Core.Clients
{
    internal sealed class UserApiClient : IUserApiClient
    {
        private readonly IModuleClient _moduleClient;

        public UserApiClient(IModuleClient moduleClient)
        {
            _moduleClient = moduleClient;
        }

        public Task<UserDto> GetAsync(string Email)
            => _moduleClient.SendAsync<UserDto>("Users/get", new { Email });
    }
}
