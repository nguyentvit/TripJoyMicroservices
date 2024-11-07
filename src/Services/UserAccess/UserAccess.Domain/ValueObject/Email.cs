using System.Text.RegularExpressions;

namespace UserAccess.Domain.ValueObject
{
    public record Email
    {
        private const string PatternEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private const int MaxLength = 255;
        public string Value { get; }
        [JsonConstructor]
        private Email(string value) => Value = value;
        public static Email Of(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, MaxLength);
            if (!Regex.IsMatch(value, PatternEmail))
            {
                throw new DomainException("Email is not in a valid format");
            }
            return new Email(value);
        }
    }
}
