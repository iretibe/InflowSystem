using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Customers.Core.Commands
{
    internal record CompleteCustomer(Guid CustomerId, string Name, string FullName, string Address, 
        string Nationality, string IdentityType, string IdentitySeries) : ICommand;
}
