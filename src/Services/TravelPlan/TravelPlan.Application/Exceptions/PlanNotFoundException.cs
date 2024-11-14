namespace TravelPlan.Application.Exceptions
{
    public class PlanNotFoundException : NotFoundException
    {
        public PlanNotFoundException(Guid Id) : base("Plan with PlanId", Id)
        {

        }
    }
}
