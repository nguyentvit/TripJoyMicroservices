namespace UserAccess.Domain.Events
{
    public record UserAddedFriendEvent(FriendId FriendId, UserId UserId) : IDomainEvent;
}
