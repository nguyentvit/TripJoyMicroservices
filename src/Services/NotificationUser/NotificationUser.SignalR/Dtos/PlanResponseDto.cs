namespace NotificationUser.SignalR.Dtos
{
    public record PlanResponseDto(Guid PlanId, List<Guid> UserIds);
}
