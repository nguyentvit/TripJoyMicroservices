namespace TravelPlan.Application.Dtos
{
    public record PlanDetailResponseDto(
        string Title,
        string? Avatar,
        DateTime StartDate,
        DateTime EndDate,
        decimal EstimatedBudget,
        string Note,
        PlanDetailResponseProvinceDto ProvinceStart,
        PlanDetailResponseProvinceDto ProvinceEnd,
        PlanVehicle Vehicle,
        PlanStatus Status,
        CreationMethod Method,
        List<PlanDetailResponsePlanLocationDto> Locations,
        List<PlanDetailResponseMemberDto> Members,
        List<PlanDetailResponseInvitationDto> Invitations
        );
    public record PlanDetailResponsePlanLocationDto(
        string Note,
        int Order,
        PlanLocationStatus Status,
        PlanDetailResponseLocationDto Location,
        List<PlanDetailResponseExpenseDto> Expenses
        );
    public record PlanDetailResponseMemberDto(
        Guid PlanMemberId,
        Guid MemberId,
        MemberRole Role
        );
    public record PlanDetailResponseInvitationDto(
        Guid PlanInvitationId,
        Guid InviterId,
        Guid InviteeId
        );
    public record PlanDetailResponseProvinceDto(
        Guid ProvinceId,
        string Name
        );
    public record PlanDetailResponseLocationDto(
        Guid LocationId,
        string Name,
        double Latitude,
        double Longitude
        );
    public record PlanDetailResponseExpenseDto(
        string Title,
        string Note,
        decimal Amount
        );
}
