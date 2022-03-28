using InflowSystem.Shared.Abstractions.Kernel.Exceptions;

namespace InflowSystem.Shared.Abstractions.Kernel.ValueObjects
{
    public record Nationality
    {
        private static readonly HashSet<string> AllowedValues = new()
        {
            "PL",
            "DE",
            "FR",
            "ES",
            "GB"
        };

        public string Value { get; }

        public Nationality(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 2)
            {
                throw new InvalidNationalityException(value);
            }

            value = value.ToUpperInvariant();

            if (!AllowedValues.Contains(value))
            {
                throw new UnsupportedNationalityException(value);
            }

            Value = value;
        }

        public static implicit operator Nationality(string value) => value is null ? null : new Nationality(value);

        public static implicit operator string(Nationality value) => value?.Value;
    }
}
