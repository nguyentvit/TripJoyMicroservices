namespace TravelPlan.Application.Dtos
{
    public record PlanUpdateDto(
        string Title,
        string? Avatar,
        DateTime StartDate,
        DateTime EndDate,
        decimal EstimatedBudget,
        Visibility Visibility);
}
