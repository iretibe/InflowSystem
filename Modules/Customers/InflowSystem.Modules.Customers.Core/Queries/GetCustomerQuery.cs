using InflowSystem.Modules.Customers.Core.DTO;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Customers.Core.Queries
{
    internal class GetCustomerQuery : IQuery<CustomerDetailDto>
    {
        public Guid CustomerId { get; set; }
    }
}
