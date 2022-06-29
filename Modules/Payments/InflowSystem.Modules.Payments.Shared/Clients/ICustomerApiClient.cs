using InflowSystem.Modules.Payments.Shared.Clients.DTO;

namespace InflowSystem.Modules.Payments.Shared.Clients
{
    internal interface ICustomerApiClient
    {
        Task<CustomerDto> GetAsync(Guid customerId);
    }
}
