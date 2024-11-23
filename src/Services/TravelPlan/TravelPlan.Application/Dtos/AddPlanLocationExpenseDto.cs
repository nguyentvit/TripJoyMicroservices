namespace TravelPlan.Application.Dtos
{
    public record AddPlanLocationExpenseDto(List<AddPlanLocationUserSpenderId> UserSpenderIds, Guid PayerId, decimal Amount);
    public record AddPlanLocationUserSpenderId(Guid UserId);
}
