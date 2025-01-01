namespace PostManagement.Domain.ValueObjects
{
    public record LocationName
    {
        public string Value { get; }
        private LocationName(string value) => Value = value;
        public static LocationName Of(string value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
            return new LocationName(value);
        }
    }
}
