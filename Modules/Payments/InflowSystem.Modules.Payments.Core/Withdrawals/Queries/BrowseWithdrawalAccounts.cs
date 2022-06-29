using InflowSystem.Modules.Payments.Core.Withdrawals.DTO;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Payments.Core.Withdrawals.Queries
{
    internal class BrowseWithdrawalAccounts : PagedQuery<WithdrawalAccountDto>
    {
        public Guid? CustomerId { get; set; }
        public string Currency { get; set; }
    }
}
