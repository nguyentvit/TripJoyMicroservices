namespace TravelPlan.Domain.ValueObjects
{
    public record PlanVehicleId
    {
        public Guid Value { get; }
        private PlanVehicleId(Guid value) => Value = value;
        public static PlanVehicleId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new PlanVehicleId(value);
        }
    }
}
