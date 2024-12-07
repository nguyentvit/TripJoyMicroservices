namespace TravelPlan.Application.Dtos
{
    public record PlanInvitationUserAvailableDto(Guid UserId, string UserName, string? Avatar, InvitationStatus Status);
}
