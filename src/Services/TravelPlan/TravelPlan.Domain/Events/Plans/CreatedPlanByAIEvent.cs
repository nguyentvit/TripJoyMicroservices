namespace TravelPlan.Domain.Events.Plans
{
    public record CreatedPlanByAIEvent(Plan Plan, List<PlanLocation> PlanLocations) : IDomainEvent;
}
