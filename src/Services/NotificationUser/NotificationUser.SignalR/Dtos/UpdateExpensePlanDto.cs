namespace NotificationUser.SignalR.Dtos
{
    public record UpdateExpensePlanDto(Guid PlanLocationId, Guid PayerId, List<Guid> UserSpenderIds);
}
