namespace TravelPlan.Domain.ValueObjects
{
    public class PlanMemberId
    {
        public Guid Value { get; }
        private PlanMemberId(Guid value) => Value = value;
        public static PlanMemberId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("FriendId cannot be empty.");
            }

            return new PlanMemberId(value);
        }
    }
}
