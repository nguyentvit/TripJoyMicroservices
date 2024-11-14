namespace TravelPlan.Domain.ValueObjects
{
    public record PlanLocationId
    {
        public Guid Value { get; }
        private PlanLocationId(Guid value) => Value = value;
        public static PlanLocationId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("FriendId cannot be empty.");
            }
            return new PlanLocationId(value);
        }
    }
}
