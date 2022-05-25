using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Users.Core.Exceptions
{
    internal class InvalidCredentialsException : InflowException
    {
        public InvalidCredentialsException() : base("Invalid credentials.")
        {
        }
    }
}
