using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Customers.Core.Commands
{
    public record CreateCustomer(string Email) : ICommand;
}
