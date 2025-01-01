namespace TravelPlan.Application.Dtos
{
    public record CreatePlanByAIDto(
        string Title,
        DateTime StartDate,
        DateTime EndDate,
        decimal EstimatedBudget,
        string ProvinceStart,
        string ProvinceEnd,
        CreationMethod Method,
        PlanVehicle Vehicle,
        List<CreatePlanByAIPlanLocationDto> PlanLocations
        );

    public record CreatePlanByAIPlanLocationDto(
        double Latitude,
        double Longitude,
        string Name,
        string Address,
        DateTime EstimatedStartDate
        );

}
