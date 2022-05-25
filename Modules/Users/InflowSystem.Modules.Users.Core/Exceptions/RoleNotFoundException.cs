using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Users.Core.Exceptions
{
    internal class RoleNotFoundException : InflowException
    {
        public RoleNotFoundException(string role) : base($"Role: '{role}' was not found.")
        {
        }
    }
}
