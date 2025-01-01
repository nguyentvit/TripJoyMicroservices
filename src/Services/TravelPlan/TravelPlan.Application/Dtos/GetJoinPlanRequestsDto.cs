namespace TravelPlan.Application.Dtos
{
    public record GetJoinPlanRequestsDto(Guid UserId, string UserName, string? Avatar, DateTime? AppliedAt, string Introduction);
}
