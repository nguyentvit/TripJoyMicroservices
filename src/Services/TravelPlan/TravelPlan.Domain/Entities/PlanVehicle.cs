namespace TravelPlan.Domain.Entities
{
    public class PlanVehicle : Entity<PlanVehicleId>
    {
        public Vehicle Vehicle { get; }
        private PlanVehicle(Vehicle vehicle) => Vehicle = vehicle;
        private PlanVehicle() { }
        public static PlanVehicle Of(string value)
        {
            if (Enum.TryParse<Vehicle>(value, true, out Vehicle vehicle))
                return new PlanVehicle(vehicle);

            throw new DomainException($"Invalid vehicle type: {value}");
        }
    }
}
