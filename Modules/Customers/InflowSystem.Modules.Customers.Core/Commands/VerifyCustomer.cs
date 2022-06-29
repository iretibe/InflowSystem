using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Customers.Core.Commands
{
    internal record VerifyCustomer(Guid CustomerId) : ICommand;
}
