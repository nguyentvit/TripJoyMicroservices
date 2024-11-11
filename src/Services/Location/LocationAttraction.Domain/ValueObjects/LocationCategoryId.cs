namespace LocationAttraction.Domain.ValueObjects
{
    public record LocationCategoryId
    {
        public Guid Value { get; }
        [JsonConstructor]
        private LocationCategoryId(Guid value) => Value = value;
        public static LocationCategoryId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("AccountId cannot be empty.");
            }

            return new LocationCategoryId(value);
        }
    }
}
