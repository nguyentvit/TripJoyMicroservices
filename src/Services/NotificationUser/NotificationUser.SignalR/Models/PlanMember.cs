namespace NotificationUser.SignalR.Models
{
    public class PlanMember
    {
        public Guid Id { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
        public Guid PlanId { get; set; } = default!;
        public Plan Plan { get; set; } = default!;
        public PlanMember(Guid userId, Guid planId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            PlanId = planId;
        }
        private PlanMember() { }

    }
}
