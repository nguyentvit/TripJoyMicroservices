using Microsoft.EntityFrameworkCore;

namespace Chat.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<ChatRoom> ChatRooms { get; }
        DbSet<ChatMessage> ChatMessages { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
