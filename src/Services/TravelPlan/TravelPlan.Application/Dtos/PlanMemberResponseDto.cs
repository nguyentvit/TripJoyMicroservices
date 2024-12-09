namespace TravelPlan.Application.Dtos
{
    public record PlanMemberResponseDto(Guid UserId, MemberRole Role, string Name, string? Avatar);
}
