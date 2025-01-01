namespace TravelPlan.Application.Dtos
{
    public record GetPlansAvailableToJoinDto(Guid Id, string Title, string? Avatar, DateTime StartDate, DateTime EndDate, decimal EstimatedBudget, GetPlansAvailableToJoinDtoProvince ProvinceStart, GetPlansAvailableToJoinDtoProvince ProvinceEnd, bool ApplyStatus);
    public record GetPlansAvailableToJoinDtoProvince(Guid ProvinceId, string ProvinceName);
}
