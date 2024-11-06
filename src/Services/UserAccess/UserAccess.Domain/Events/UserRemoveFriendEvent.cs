namespace UserAccess.Domain.Events
{
    public record UserRemoveFriendEvent(User User, UserId FriendId) : IDomainEvent;
}
