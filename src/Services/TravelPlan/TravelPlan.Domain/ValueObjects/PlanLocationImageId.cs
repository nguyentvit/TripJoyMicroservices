namespace TravelPlan.Domain.ValueObjects
{
    public record PlanLocationImageId
    {
        public Guid Value { get; }
        private PlanLocationImageId(Guid value) => Value = value;
        public static PlanLocationImageId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new PlanLocationImageId(value);
        }
    }
}
