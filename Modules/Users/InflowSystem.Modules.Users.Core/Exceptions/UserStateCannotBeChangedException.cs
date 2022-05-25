using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Users.Core.Exceptions
{
    internal class UserStateCannotBeChangedException : InflowException
    {
        public string State { get; }
        public Guid UserId { get; }

        public UserStateCannotBeChangedException(string state, Guid userId)
            : base($"User state cannot be changed to: '{state}' for user with ID: '{userId}'.")
        {
            State = state;
            UserId = userId;
        }
    }
}
