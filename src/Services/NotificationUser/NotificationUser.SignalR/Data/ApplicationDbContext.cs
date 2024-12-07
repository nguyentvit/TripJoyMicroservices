namespace NotificationUser.SignalR.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<PlanMember> PlanMembers => Set<PlanMember>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserFriend> UserFriends => Set<UserFriend>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Plan>()
                .HasMany(p => p.PlanMembers)
                .WithOne(p => p.Plan)
                .HasForeignKey(p => p.PlanId)
                .IsRequired();

            builder.Entity<User>()
                .HasMany(u => u.UserFriends)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
