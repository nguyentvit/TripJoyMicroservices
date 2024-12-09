namespace Chat.Domain.ValueObjects
{
    public record ChatRoomMemberId
    {
        public Guid Value { get; }
        private ChatRoomMemberId(Guid value) => Value = value;
        public static ChatRoomMemberId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new ChatRoomMemberId(value);
        }
    }
}
