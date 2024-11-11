namespace LocationAttraction.Domain.ValueObjects
{
    public record Name
    {
        private const int MinLength = 3;
        private const int MaxLength = 50;
        public string Value { get; }
        [JsonConstructor]
        private Name(string value) => Value = value;
        public static Name Of(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            ArgumentOutOfRangeException.ThrowIfLessThan(value.Length, MinLength);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, MaxLength);

            return new Name(value);
        }
    }
}
