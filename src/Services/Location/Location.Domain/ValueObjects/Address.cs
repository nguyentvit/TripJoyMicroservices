namespace Location.Domain.ValueObjects
{
    public record Address
    {
        public string Value { get; }
        [JsonConstructor]
        private Address(string value) => Value = value;
        public static Address Of(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            return new Address(value);
        }
    }
}
