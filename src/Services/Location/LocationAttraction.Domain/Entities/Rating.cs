namespace LocationAttraction.Domain.Entities
{
    public class Rating : Entity<RatingId>
    {
        public UserId UserId { get; } = default!;
        public double Value { get; private set; }
        [JsonConstructor]
        private Rating(UserId userId, double value)
        {
            UserId = userId;
            Value = value;
        }
        private Rating(RatingId id, UserId userId, double value)
        {
            Id = id;
            UserId = userId;
            Value = value;
        }
        private Rating() { }
        public static Rating Of(UserId userId, double value)
        {
            if (value < 0 || value > 5)
            {
                throw new DomainException("Rating must be between 0 and 5.");
            }
            return new Rating(RatingId.Of(Guid.NewGuid()), userId, value);
        }
        public void UpdateRating(double value)
        {
            Value = value;
        }

    }
}
