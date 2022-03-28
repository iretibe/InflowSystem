﻿using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Customers.Core.Exceptions
{
    internal class CannotVerifyCustomerException : InflowException
    {
        public Guid CustomerId { get; }

        public CannotVerifyCustomerException(Guid customerId)
            : base($"Customer with ID: '{customerId}' cannot be verified.")
        {
            CustomerId = customerId;
        }
    }
}
