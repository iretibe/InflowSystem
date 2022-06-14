using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Customers.Core.Exceptions
{
    internal class UserNotFoundException : InflowException
    {
        public UserNotFoundException(string email) : base($"User with email: {email} was not found.")
        {
        }
    }
}
