namespace TravelPlan.Application.Plans.Queries.GetPlans
{
    public record GetPlansQuery(Guid UserId, PaginationRequest PaginationRequest) : IQuery<GetPlansResult>;
    public record GetPlansResult(PaginationResult<PlanResponseDto> Plans);
}
