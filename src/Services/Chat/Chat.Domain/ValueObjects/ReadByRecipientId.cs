namespace Chat.Domain.ValueObjects
{
    public record ReadByRecipientId
    {
        public Guid Value { get; }
        private ReadByRecipientId(Guid value) => Value = value;
        public static ReadByRecipientId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new ReadByRecipientId(value);
        }
    }
}
