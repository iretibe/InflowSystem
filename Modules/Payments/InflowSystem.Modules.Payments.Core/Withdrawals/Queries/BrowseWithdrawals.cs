using InflowSystem.Modules.Payments.Core.Withdrawals.DTO;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Queries
{
    internal class BrowseWithdrawals : PagedQuery<WithdrawalDto>
    {
        public Guid? AccountId { get; set; }
        public Guid? CustomerId { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}
