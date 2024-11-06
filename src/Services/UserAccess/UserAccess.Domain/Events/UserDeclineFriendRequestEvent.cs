namespace UserAccess.Domain.Events
{
    public record UserDeclineFriendRequestEvent(User User, UserId SenderId) : IDomainEvent;
}
