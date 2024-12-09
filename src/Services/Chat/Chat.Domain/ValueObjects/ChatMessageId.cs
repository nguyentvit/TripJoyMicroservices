namespace Chat.Domain.ValueObjects
{
    public record ChatMessageId
    {
        public Guid Value { get; }
        private ChatMessageId(Guid value) => Value = value;
        public static ChatMessageId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new ChatMessageId(value);
        }
    }
}
