namespace Location.Domain.ValueObjects
{
    public record LocationRatingId
    {
        public Guid Value { get; }
        [JsonConstructor]
        private LocationRatingId(Guid value) => Value = value;
        public static LocationRatingId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new LocationRatingId(value);
        }

    }
}
