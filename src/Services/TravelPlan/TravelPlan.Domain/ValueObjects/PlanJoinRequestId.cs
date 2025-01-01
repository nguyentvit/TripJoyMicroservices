namespace TravelPlan.Domain.ValueObjects
{
    public record PlanJoinRequestId
    {
        public Guid Value { get; }
        private PlanJoinRequestId(Guid value) => Value = value;
        public static PlanJoinRequestId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }
            return new PlanJoinRequestId(value);
        }
    }
}
