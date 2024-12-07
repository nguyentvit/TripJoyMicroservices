namespace NotificationUser.SignalR.Data.IRepository
{
    public interface IApplicationDbContext
    {
        DbSet<Plan> Plans { get; }
        DbSet<PlanMember> PlanMembers { get; }
        DbSet<User> Users { get; }
        DbSet<UserFriend> UserFriends { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
