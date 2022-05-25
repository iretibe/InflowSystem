using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Users.Core.Exceptions
{
    internal class InvalidUserStateException : InflowException
    {
        public string State { get; }

        public InvalidUserStateException(string state) : base($"User state is invalid: '{state}'.")
        {
            State = state;
        }
    }
}
