using InflowSystem.Modules.Payments.Core.Deposits.DTO;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Payments.Core.Deposits.Queries
{
    internal class BrowseDeposits : PagedQuery<DepositDto>
    {
        public Guid? AccountId { get; set; }
        public Guid? CustomerId { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}
