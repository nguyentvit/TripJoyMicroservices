namespace NotificationUser.SignalR.Data.IRepository
{
    public interface IPlanRepository
    {
        Task<PlanResponseDto> CreatePlan(Plan plan, CancellationToken cancellationToken = default);
        Task<PlanResponseDto> GetPlan(Guid planId, CancellationToken cancellationToken = default);
        Task<bool> AddMember(Guid planId, Guid userId, CancellationToken cancellationToken = default);
        Task<bool> RemoveMember(Guid planId, Guid userId, CancellationToken cancellationToken = default);
        Task<List<PlanResponseDto>> GetPlansByUserId(Guid userId, CancellationToken cancellation = default);
    }
}
