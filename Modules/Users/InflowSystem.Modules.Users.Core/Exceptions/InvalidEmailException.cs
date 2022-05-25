using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Users.Core.Exceptions
{
    internal class InvalidEmailException : InflowException
    {
        public string Email { get; }

        public InvalidEmailException(string email) : base($"State is invalid: '{email}'.")
        {
            Email = email;
        }
    }
}
