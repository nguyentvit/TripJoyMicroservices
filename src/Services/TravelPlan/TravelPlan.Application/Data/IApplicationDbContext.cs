namespace TravelPlan.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Plan> Plans { get; }
        DbSet<PlanLocation> PlanLocations { get; }
        DbSet<Province> Provinces { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
