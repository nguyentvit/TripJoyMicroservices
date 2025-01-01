namespace TravelPlan.Application.Dtos
{
    public record GetPlanAvailableToJoinByPlanIdDto(GetPlanAvailableToJoinByPlanIdDtoCoordinates Coordinates, int Order, DateTime EstimatedStartDate, string LocationName, string LocationAddress);
    public record GetPlanAvailableToJoinByPlanIdDtoCoordinates(double Longitude, double Latitude);
    public record GetPlanAvailableToJoinByPlanIdDtoPlan(Guid PlanId, string Title, string? Avatar, DateTime StartDate, DateTime EndDate, decimal EstimatedBudget, GetPlanAvailableToJoinByPlanIdDtoPlanProvince ProvinceStart, GetPlanAvailableToJoinByPlanIdDtoPlanProvince ProvinceEnd, bool ApplyStatus);
    public record GetPlanAvailableToJoinByPlanIdDtoPlanLeadUser(Guid UserId, string UserName, string? Avatar);
    public record GetPlanAvailableToJoinByPlanIdDtoPlanProvince(Guid ProvinceId, string ProvinceName);
}
