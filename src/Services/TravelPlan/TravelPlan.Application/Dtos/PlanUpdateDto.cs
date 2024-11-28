namespace TravelPlan.Application.Dtos
{
    public record PlanUpdateDto(
        string Title,
        IFormFile? Avatar,
        DateTime StartDate,
        DateTime EndDate,
        decimal EstimatedBudget,
        Guid ProvinceStartId,
        Guid ProvinceEndId,
        PlanVehicle Vehicle);
}
