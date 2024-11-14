namespace TravelPlan.Domain.ValueObjects
{
    public record PlanInvitationId
    {
        public Guid Value { get; }
        private PlanInvitationId(Guid value) => Value = value;
        public static PlanInvitationId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new PlanInvitationId(value);
        }
    }
}
