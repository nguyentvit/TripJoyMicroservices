namespace NotificationUser.SignalR.Models
{
    public class Plan
    {
        public Guid Id { get; set; } = default!;
        public ICollection<PlanMember> PlanMembers { get; } = new List<PlanMember>();
        public Plan(Guid id)
        {
            Id = id;
        }
        private Plan() { }

    }
}
