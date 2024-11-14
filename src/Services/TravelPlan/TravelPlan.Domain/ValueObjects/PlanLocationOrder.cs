namespace TravelPlan.Domain.ValueObjects
{
    public record PlanLocationOrder
    {
        public int Value { get; }
        private PlanLocationOrder(int value) => Value = value;
        public static PlanLocationOrder Of(int value)
        {
            if (value <= 0)
                throw new DomainException("PlanLocationOrder value must be greater than 0.");

            return new PlanLocationOrder(value);
        }
    }
}
