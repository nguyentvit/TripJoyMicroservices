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
        CreationMethod Method,
        PlanResponseProvinceDto ProvinceStart,
        PlanResponseProvinceDto ProvinceEnd,
        List<PlanResponseImageDto> Images,
        PlanJoinStatus JoinStatus
        );

    public record PlanResponseLocationDto(
        Guid Id,
        PlanResponseLocationDtoCoordinates Coordinates,
        int Order,
        string Name,
        string Address,
        DateTime EstimatedStartDate
        );
    public record PlanResponseProvinceDto(Guid ProvinceId, string ProvinceName);
    public record PlanResponseLocationDtoCoordinates(double Latitude, double Longitude);
    public record PlanResponseImageDto(string Url);
}
