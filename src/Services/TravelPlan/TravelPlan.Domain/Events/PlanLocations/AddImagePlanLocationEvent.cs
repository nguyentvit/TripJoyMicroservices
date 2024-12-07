namespace TravelPlan.Domain.Events.PlanLocations
{
    public record AddImagePlanLocationEvent(PlanLocation PlanLocation, UserId UserId, FileImg Image) : IDomainEvent;
}
