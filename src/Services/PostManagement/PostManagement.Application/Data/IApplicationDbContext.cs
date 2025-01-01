namespace PostManagement.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Post> Posts { get; }
        DbSet<PlanPost> PlanPosts { get; }
        DbSet<Comment> Comments { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
