namespace UserAccess.Domain.ValueObject
{
    public record FriendRequestId
    {
        public Guid Value { get; }
        private FriendRequestId(Guid value) => Value = value;
        public static FriendRequestId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("FriendRequestId cannot be empty.");
            }

            return new FriendRequestId(value);
        }
    }
}
