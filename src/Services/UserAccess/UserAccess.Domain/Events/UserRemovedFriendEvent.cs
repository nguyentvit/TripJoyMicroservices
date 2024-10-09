namespace UserAccess.Domain.Events
{
    public record UserRemovedFriendEvent(FriendId FriendId, UserId UserId) : IDomainEvent;
}
