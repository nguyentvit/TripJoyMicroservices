namespace TravelPlan.Domain.Models
{
    public class Plan : Aggregate<PlanId>
    {
        private readonly List<PlanMember> _members = new();
        private readonly List<PlanInvitation> _invitations = new();
        private readonly List<PlanLocationId> _planLocationIds = new();
        private readonly List<PlanVehicle> _vehicles = new();
        public IReadOnlyList<PlanMember> Members => _members.AsReadOnly();
        public IReadOnlyList<PlanInvitation> Invitations => _invitations.AsReadOnly();
        public IReadOnlyList<PlanLocationId> PlanLocationIds => _planLocationIds.AsReadOnly();
        public IReadOnlyList<PlanVehicle> Vehicles => _vehicles.AsReadOnly();
        public Title Title { get; private set; } = default!;
        public Image? Avatar { get; private set; }
        public Date StartDate { get; private set; } = default!;
        public Date EndDate { get; private set; } = default!;
        public Note Note { get; private set; } = default!;
        public Money EstimatedBudget { get; private set; } = default!;
        public Visibility Visibility { get; private set; }
        public PlanStatus Status { get; private set; }
        public CreationMethod Method { get; private set; }
        private Plan() { }
    }
}
