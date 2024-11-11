﻿namespace LocationAttraction.Domain.ValueObjects
{
    public record Coordinates
    {
        public double Latitude { get; }
        public double Longitude { get; }
        [JsonConstructor]
        private Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public static Coordinates Of(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90)
            {
                throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude must be between -90 and 90.");
            }

            if (longitude < -180 || longitude > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude must be between -180 and 180.");
            }

            return new Coordinates(latitude, longitude);
        }
    }
}
