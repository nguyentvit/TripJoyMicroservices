namespace PostManagement.Domain.ValueObjects
{
    public record PostPlanLocationId
    {
        public Guid Value { get; }
        private PostPlanLocationId(Guid value) => Value = value;
        public static PostPlanLocationId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("PlanId cannot be empty.");
            }

            return new PostPlanLocationId(value);
        }
    }
}
