using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Customers.Core.Exceptions
{
    internal class CustomerAlreadyExistsException : InflowException
    {
        public Guid CustomerId { get; }

        public CustomerAlreadyExistsException(Guid customerId) : base($"Customer with ID {customerId} already exists.")
        {
            CustomerId = customerId;
        }
    }
}
