namespace TravelPlan.Application.Dtos
{
    public record PlanLocationResponseDto(
        Guid PlanLocationId,
        Guid PlanId,
        Guid LocationId,
        double Longitude,
        double Latitude,
        int Order,
        string Note,
        PlanLocationStatus Status,
        Guid? PayerId,
        decimal? Amount,
        List<PlanLocationImageResponse> Images,
        List<PlanLocationUserSpenderResponse> UserSpenders
        );
    public record PlanLocationImageResponse(string Url);
    public record PlanLocationUserSpenderResponse(Guid UserSpenderId);
}
