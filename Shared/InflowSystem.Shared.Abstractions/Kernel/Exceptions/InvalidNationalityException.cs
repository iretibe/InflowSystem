using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Shared.Abstractions.Kernel.Exceptions
{
    public class InvalidNationalityException : InflowException
    {
        public string Nationality { get; }

        public InvalidNationalityException(string nationality) : base($"Nationality: '{nationality}' is invalid.")
        {
            Nationality = nationality;
        }
    }
}
