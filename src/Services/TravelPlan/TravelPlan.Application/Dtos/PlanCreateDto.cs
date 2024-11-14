namespace TravelPlan.Application.Dtos
{
    public record PlanCreateDto(
        string Title, 
        string? Avatar, 
        DateTime StartDate,
        DateTime EndDate,
        decimal EstimatedBudget, 
        Visibility Visibility, 
        CreationMethod Method);
}
