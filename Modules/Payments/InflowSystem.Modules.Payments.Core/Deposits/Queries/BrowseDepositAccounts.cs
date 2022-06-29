using InflowSystem.Modules.Payments.Core.Deposits.DTO;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Payments.Core.Deposits.Queries
{
    internal class BrowseDepositAccounts : PagedQuery<DepositAccountDto>
    {
        public Guid? CustomerId { get; set; }
        public string Currency { get; set; }
    }
}
