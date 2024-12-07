namespace TravelPlan.Domain.Events.PlanLocations
{
    public record RemoveImagePlanLocationEvent(PlanLocation PlanLocation, Image Image) : IDomainEvent;
}
