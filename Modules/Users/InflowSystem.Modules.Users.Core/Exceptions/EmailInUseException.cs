using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Users.Core.Exceptions
{
    internal class EmailInUseException : InflowException
    {
        public EmailInUseException() : base("Email is already in use.")
        {
        }
    }
}
