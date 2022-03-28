using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Customers.Core.Exceptions
{
    internal class InvalidCustomerNameException : InflowException
    {
        public Guid CustomerId { get; }

        public InvalidCustomerNameException(Guid customerId)
            : base($"Customer with ID: '{customerId}' has invalid name.")
        {
            CustomerId = customerId;
        }
    }
}
