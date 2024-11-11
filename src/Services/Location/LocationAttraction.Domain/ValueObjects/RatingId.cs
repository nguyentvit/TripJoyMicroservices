namespace LocationAttraction.Domain.ValueObjects
{
    public record RatingId
    {
        public Guid Value { get; }
        [JsonConstructor]
        private RatingId(Guid value) => Value = value;
        public static RatingId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("FriendId cannot be empty.");
            }
            return new RatingId(value);
        }

    }
}
