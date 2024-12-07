namespace NotificationUser.SignalR.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid userId) : base("User ", userId) { }
    }
}
