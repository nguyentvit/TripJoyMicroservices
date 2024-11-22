namespace TravelPlan.Domain.ValueObjects
{
    public record PlanLocationUserSpenderId
    {
        public Guid Value { get; }
        private PlanLocationUserSpenderId(Guid value) => Value = value;
        public static PlanLocationUserSpenderId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("FriendId cannot be empty.");
            }

            return new PlanLocationUserSpenderId(value);
        }
    }
}
