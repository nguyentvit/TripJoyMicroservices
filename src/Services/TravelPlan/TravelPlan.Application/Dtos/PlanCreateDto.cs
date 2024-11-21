namespace TravelPlan.Application.Dtos
{
    public record PlanCreateDto(
        string Title, 
        string? Avatar, 
        DateTime StartDate,
        DateTime EndDate,
        decimal EstimatedBudget,
        Guid ProvinceStartId,
        Guid ProvinceEndId,
        CreationMethod Method,
        PlanVehicle Vehicle);
}
