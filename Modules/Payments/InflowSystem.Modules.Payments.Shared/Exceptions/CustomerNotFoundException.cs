using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Payments.Shared.Exceptions
{
    internal class CustomerNotFoundException : InflowException
    {
        public Guid CustomerId { get; }

        public CustomerNotFoundException(Guid customerId) : base($"Customer with ID: '{customerId}' was not found.")
        {
            CustomerId = customerId;
        }
    }
}
