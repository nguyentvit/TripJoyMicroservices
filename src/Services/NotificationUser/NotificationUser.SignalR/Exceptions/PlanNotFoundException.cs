namespace NotificationUser.SignalR.Exceptions
{
    public class PlanNotFoundException : NotFoundException
    {
        public PlanNotFoundException(Guid planId) : base("Plan", planId) { }
    }
}
