using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Shared.Abstractions.Kernel.Exceptions
{
    public class InvalidEmailException : InflowException
    {
        public string Email { get; }

        public InvalidEmailException(string email) : base($"Email: '{email}' is invalid")
        {
            Email = email;
        }
    }
}
