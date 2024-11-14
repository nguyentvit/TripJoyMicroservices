using System.Reflection;
using TravelPlan.Application.Data;

namespace TravelPlan.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<PlanLocation> PlanLocations => Set<PlanLocation>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
