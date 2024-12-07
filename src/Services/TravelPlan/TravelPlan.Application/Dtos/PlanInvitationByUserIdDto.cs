namespace TravelPlan.Application.Dtos
{
    public record PlanInvitationByUserIdDto(Guid PlanId, Guid InviterId, string Title, DateTime StartDate, DateTime EndDate, string InviterName, string? InviterAvatar);
}
