namespace LocationAttraction.Domain.ValueObjects
{
    public record AverageRating
    {
        public double Value { get; private set; }
        public int NumRatings { get; private set; }

        [JsonConstructor]
        private AverageRating(double value, int numRatings)
        {
            Value = value;
            NumRatings = numRatings;
        }
        public static AverageRating Of(double value = 0, int numRatings = 0)
        {
            return new AverageRating(value, numRatings);
        }
        public void AddNewRating(Rating rating)
        {
            Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
        }
        public void UpdateRating(double oldValue, double newValue)
        {
            if (NumRatings == 0)
            {
                throw new DomainException("No ratings to update.");
            }

            Value = ((Value * NumRatings) - oldValue + newValue) / NumRatings;
        }
        public void RemoveRating(Rating rating)
        {
            if (NumRatings == 0)
            {
                throw new DomainException("No ratings to remove.");
            }
            if (NumRatings == 1)
            {
                Value = 0;
                NumRatings = 0;
            }
            else
            {
                Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
            }
        }
    }
}
