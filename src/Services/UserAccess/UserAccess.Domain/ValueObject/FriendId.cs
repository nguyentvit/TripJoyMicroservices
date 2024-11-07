namespace UserAccess.Domain.ValueObject
{
    public record FriendId
    {
        public Guid Value { get; }
        [JsonConstructor]
        private FriendId(Guid value) => Value = value;
        public static FriendId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("FriendId cannot be empty.");
            }

            return new FriendId(value);
        }
    }
}
