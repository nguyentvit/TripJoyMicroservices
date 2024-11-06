namespace UserAccess.Domain.ValueObject
{
    public record SendFriendRequestId
    {
        public Guid Value { get; }
        private SendFriendRequestId(Guid value) => Value = value;
        public static SendFriendRequestId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("SendFriendRequestId cannot be empty.");
            }

            return new SendFriendRequestId(value);
        }
    }
}
