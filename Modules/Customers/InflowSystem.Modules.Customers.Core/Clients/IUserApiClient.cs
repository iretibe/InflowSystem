using InflowSystem.Modules.Customers.Core.Clients.DTO;

namespace InflowSystem.Modules.Customers.Core.Clients
{
    internal interface IUserApiClient
    {
        Task<UserDto> GetAsync(string Email);
    }
}
