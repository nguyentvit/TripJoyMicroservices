namespace NotificationUser.SignalR.Data.IRepository
{
    public interface IUserRepository
    {
        Task<UserResponseDto> CreateUser(User user, CancellationToken cancellationToken = default);
        Task<UserResponseDto> GetUser(Guid userId, CancellationToken cancellationToken = default);
        Task<bool> AddFriend(Guid userIdFirst, Guid userIdSecond, CancellationToken cancellationToken = default);
        Task<bool> RemoveFriend(Guid userIdFirst, Guid userIdSecond, CancellationToken cancellationToken = default);
        Task<bool> AddConnectionId(Guid userId, string connectionId, CancellationToken cancellationToken = default);
        Task<Guid> RemoveConnectionId(string connectionId, CancellationToken cancellationToken = default);
        Task<List<Guid>> GetUserIds(CancellationToken cancellationToken = default);
    }
}
