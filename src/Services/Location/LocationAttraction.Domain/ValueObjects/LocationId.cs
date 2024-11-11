namespace LocationAttraction.Domain.ValueObjects
{
    public record LocationId
    {
        public Guid Value { get; }
        [JsonConstructor]
        private LocationId(Guid value) => Value = value;
        public static LocationId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new LocationId(value);
        }
    }
}
