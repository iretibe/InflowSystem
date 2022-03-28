using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Customers.Core.Exceptions
{
    internal class CustomerNotActiveException : InflowException
    {
        public Guid CustomerId { get; }

        public CustomerNotActiveException(Guid customerId)
            : base($"Customer with ID: '{customerId}' is not active.")
        {
            CustomerId = customerId;
        }
    }
}
