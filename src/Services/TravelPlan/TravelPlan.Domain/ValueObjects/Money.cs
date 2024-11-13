namespace TravelPlan.Domain.ValueObjects
{
    public record Money
    {
        public decimal Value { get; }
        private Money(decimal value) => Value = value;
        public static Money Of(decimal value)
        {
            if (value < 0)
                throw new DomainException("Money value must be non-negative");

            return new Money(value);
        }
    }
}
