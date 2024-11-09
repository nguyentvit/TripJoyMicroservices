namespace Location.Domain.ValueObjects
{
    public record ImageId
    {
        public Guid Value { get; }
        [JsonConstructor]
        private ImageId(Guid value) => Value = value;
        public static ImageId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("FriendId cannot be empty.");
            }
            return new ImageId(value);
        }
    }
}
