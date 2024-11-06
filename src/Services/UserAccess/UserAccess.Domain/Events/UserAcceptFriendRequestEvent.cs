namespace UserAccess.Domain.Events
{
    public record UserAcceptFriendRequestEvent(User User, UserId SenderId) : IDomainEvent;
}
