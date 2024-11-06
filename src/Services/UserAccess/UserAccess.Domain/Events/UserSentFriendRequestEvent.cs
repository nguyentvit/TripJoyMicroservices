namespace UserAccess.Domain.Events
{
    public record UserSentFriendRequestEvent(User User, UserId ReceiverId) : IDomainEvent;
}
