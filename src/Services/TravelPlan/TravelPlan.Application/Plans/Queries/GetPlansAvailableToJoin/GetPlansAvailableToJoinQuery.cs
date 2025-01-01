namespace TravelPlan.Application.Plans.Queries.GetPlansAvailableToJoin
{
    public record GetPlansAvailableToJoinQuery(PaginationRequest PaginationRequest, Guid UserId) : IQuery<GetPlansAvailableToJoinResult>;
    public record GetPlansAvailableToJoinResult(PaginationResult<GetPlansAvailableToJoinDto> Plans);
}
