namespace TravelPlan.Application.Dtos
{
    public record PlanResponseDto(
        Guid Id,
        Guid LeadUserId,
        string Title,
        string? Avatar,
        DateTime StartDate,
        DateTime EndDate,
        decimal EstimatedBudget,
        List<PlanResponseLocationDto> Locations,
        PlanVehicle Vehicle,
        PlanStatus Status,
        CreationMethod Method
        );

    public record PlanResponseLocationDto(
        Guid Id,
        double Latitude,
        double Longitude,
        int Order
        );
}
