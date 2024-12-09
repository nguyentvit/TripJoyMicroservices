namespace Chat.Domain.ValueObjects
{
    public record ChatRoomId
    {
        public Guid Value { get; }
        private ChatRoomId(Guid value) => Value = value;
        public static ChatRoomId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new ChatRoomId(value);
        }
    }
}
