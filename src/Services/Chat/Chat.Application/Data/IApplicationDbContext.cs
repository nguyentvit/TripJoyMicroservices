using Microsoft.EntityFrameworkCore;

namespace Chat.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<ChatRoom> ChatRooms { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
