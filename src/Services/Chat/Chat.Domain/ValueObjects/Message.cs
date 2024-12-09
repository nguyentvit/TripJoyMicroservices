namespace Chat.Domain.ValueObjects
{
    public record Message
    {
        public string Value { get; }
        private Message(string value) => Value = value;
        public static Message Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Message content cannot be null or empty.");

            return new Message(value);
        }
    }
}
