namespace TravelPlan.Application.Dtos
{
    public record PlanExpenseMembersResponseDto(Guid UserId, decimal Excess, string UserName, string? Url);
}
