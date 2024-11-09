namespace Location.Domain.Entities
{
    public class LocationRating : Entity<LocationRatingId>
    {
        public double Rating { get; }
        public int NumberOfRatings { get; }
        public double AverageRating { get; }
        private LocationRating() { }
        [JsonConstructor]
        private LocationRating(double rating, int numberOfRatings, double averageRating)
        {
            Rating = rating;
            NumberOfRatings = numberOfRatings;
            AverageRating = averageRating;
        }
        private LocationRating(LocationRatingId id, double rating, int numberOfRatings)
        {
            Id = id;
            Rating = rating;
            NumberOfRatings = numberOfRatings;
            AverageRating = Rating / numberOfRatings;
        }
        //public static LocationRating Of(double rating, int numberOfRatings)
        //{

        //}

    }
}
