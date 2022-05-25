using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Users.Core.Exceptions
{
    internal class UserNotActiveException : InflowException
    {
        public Guid UserId { get; }

        public UserNotActiveException(Guid userId) : base($"User with ID: '{userId}' is not active.")
        {
            UserId = userId;
        }
    }
}
