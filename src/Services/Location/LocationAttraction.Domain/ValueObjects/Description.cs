namespace LocationAttraction.Domain.ValueObjects
{
    public record Description
    {
        public string Value { get; }
        [JsonConstructor]
        private Description(string value) => Value = value;
        public static Description Of(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            return new Description(value);
        }
    }
}
