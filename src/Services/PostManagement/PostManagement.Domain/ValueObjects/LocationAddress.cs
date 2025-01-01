namespace PostManagement.Domain.ValueObjects
{
    public record LocationAddress
    {
        public string Value { get; }
        private LocationAddress(string value) => Value = value;
        public static LocationAddress Of(string value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
            return new LocationAddress(value);
        }
    }
}
