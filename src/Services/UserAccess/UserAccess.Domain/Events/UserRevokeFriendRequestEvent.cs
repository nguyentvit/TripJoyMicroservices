namespace UserAccess.Domain.Events
{
    public record UserRevokeFriendRequestEvent(User User, UserId ReceiverId) : IDomainEvent;
}
