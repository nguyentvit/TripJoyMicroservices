namespace TravelPlan.Domain.Events.Plans
{
    public record RemovePlanLocationEvent(Plan Plan, PlanLocation PlanLocation) : IDomainEvent;
}
