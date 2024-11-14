namespace TravelPlan.Application.Exceptions
{
    public class PlanLocationNotFoundException : NotFoundException
    {
        public PlanLocationNotFoundException(Guid Id) : base("PlanLocation with PlanLocationId", Id)
        {

        }
    }
}
