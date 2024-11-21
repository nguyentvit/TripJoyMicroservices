namespace TravelPlan.Domain.ValueObjects
{
    public record ProvinceId
    {
        public Guid Value { get; }
        private ProvinceId(Guid value) => Value = value;
        public static ProvinceId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("ProvinceId cannot be empty.");
            }

            return new ProvinceId(value);
        }
    }
}
