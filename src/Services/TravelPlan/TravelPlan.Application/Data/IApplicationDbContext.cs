namespace TravelPlan.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Plan> Plans { get; }
        DbSet<PlanLocation> PlanLocations { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
