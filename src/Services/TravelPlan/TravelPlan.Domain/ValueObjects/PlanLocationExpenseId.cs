namespace TravelPlan.Domain.ValueObjects
{
    public record PlanLocationExpenseId
    {
        public Guid Value { get; }
        private PlanLocationExpenseId(Guid value) => Value = value; 
        public static PlanLocationExpenseId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new PlanLocationExpenseId(value);
        }
    }
}
