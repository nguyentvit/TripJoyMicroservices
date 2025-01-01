namespace PostManagement.Domain.ValueObjects
{
    public record Content
    {
        public string Value { get; }
        private Content(string value) => Value = value;
        public static Content Of(string value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
            return new Content(value);
        }
    }
}
