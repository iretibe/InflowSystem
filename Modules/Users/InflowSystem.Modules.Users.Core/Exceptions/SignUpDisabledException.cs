using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Modules.Users.Core.Exceptions
{
    internal class SignUpDisabledException : InflowException
    {
        public SignUpDisabledException() : base("Sign up is disabled.")
        {
        }
    }
}
