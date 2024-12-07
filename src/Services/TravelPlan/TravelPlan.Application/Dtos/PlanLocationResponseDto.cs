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
        DateTime EstimatedStartDate,
        DateTime? CompletionDate,
        PlanLocationStatus Status,
        Guid? PayerId,
        decimal? Amount,
        string LocationName,
        string LocationAddress,
        List<PlanLocationImageResponse> Images,
        List<PlanLocationUserSpenderResponse> UserSpenders
        );
    public record PlanLocationImageResponse(string Url);
    public record PlanLocationUserSpenderResponse(Guid UserSpenderId);
}
