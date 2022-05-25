using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Users.Core.Exceptions
{
    internal class InvalidPasswordException : InflowException
    {
        public string Reason { get; }

        public InvalidPasswordException(string reason) : base($"Invalid password: {reason}.")
        {
            Reason = reason;
        }
    }
}
