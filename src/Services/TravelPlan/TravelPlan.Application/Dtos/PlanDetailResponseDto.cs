namespace TravelPlan.Application.Dtos
{
    public record PlanDetailResponseDto(
        string Title,
        DateTime EstimatedStartDate,
        DateTime EstimatedEndDate,
        CreationMethod Method,
        PlanVehicle Vehicle,
        PlanDetailProvinceResponseDto ProvinceStart,
        PlanDetailProvinceResponseDto ProvinceEnd,
        PlanStatus Status,
        string? Avatar,
        string Note,
        decimal EstimatedBudget,
        MemberRole Role
        );
    public record PlanDetailProvinceResponseDto(
        Guid ProvinceId,
        string ProvinceName
        );
}
