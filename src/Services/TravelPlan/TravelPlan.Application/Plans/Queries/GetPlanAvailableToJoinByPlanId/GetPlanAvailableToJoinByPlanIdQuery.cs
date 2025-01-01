namespace TravelPlan.Application.Plans.Queries.GetPlanAvailableToJoinByPlanId
{
    public record GetPlanAvailableToJoinByPlanIdQuery(Guid UserId, Guid PlanId, PaginationRequest PaginationRequest) : IQuery<GetPlanAvailableToJoinByPlanIdResult>;
    public record GetPlanAvailableToJoinByPlanIdResult(PaginationResult<GetPlanAvailableToJoinByPlanIdDto> PlanLocations, GetPlanAvailableToJoinByPlanIdDtoPlan Plan, GetPlanAvailableToJoinByPlanIdDtoPlanLeadUser LeadUser);
}
