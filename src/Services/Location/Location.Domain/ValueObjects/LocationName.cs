namespace Location.Domain.ValueObjects
{
    public record LocationName
    {
        private const int MinLength = 3;
        private const int MaxLength = 50;
        public string Value { get; }
        [JsonConstructor]
        private LocationName(string value) => Value = value;
        public static LocationName Of(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            ArgumentOutOfRangeException.ThrowIfLessThan(value.Length, MinLength);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, MaxLength);

            return new LocationName(value);
        }
    }
}
