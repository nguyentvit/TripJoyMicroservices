namespace TravelPlan.Application.Plans.Queries.GetPlans
{
    public record GetPlansQuery(Guid UserId, PaginationRequest PaginationRequest, KeySearch keySearch) : IQuery<GetPlansResult>;
    public record GetPlansResult(PaginationResult<PlanResponseDto> Plans);
}
