using InflowSystem.Modules.Customers.Core.DAL;
using InflowSystem.Modules.Customers.Core.DTO;
using InflowSystem.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Modules.Customers.Core.Queries.Handlers
{
    internal sealed class GetCustomerHandler : IQueryHandler<GetCustomerQuery, CustomerDetailDto>
    {
        private readonly CustomersDbContext _dbContext;

        public GetCustomerHandler(CustomersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerDetailDto> HandleAsync(GetCustomerQuery query, CancellationToken cancellationToken = default)
        {
            var customer = await _dbContext.Customers
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == query.CustomerId, cancellationToken);

            return customer?.AsDetailDto();
        }
    }
}
