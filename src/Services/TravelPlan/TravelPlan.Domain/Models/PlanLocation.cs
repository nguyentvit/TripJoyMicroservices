namespace TravelPlan.Domain.Models
{
    public class PlanLocation : Aggregate<PlanLocationId>
    {
        private readonly List<PlanLocationImage> _images = new();
        private readonly List<PlanLocationExpense> _expenses = new();
        public IReadOnlyList<PlanLocationImage> Images => _images.AsReadOnly();
        public IReadOnlyList<PlanLocationExpense> Expenses => _expenses.AsReadOnly();
        public LocationId LocationId { get; private set; } = default!;
        public PlanId PlanId { get; private set; } = default!;
        public Note Note { get; private set; } = default!;
        public PlanLocationOrder Order { get; private set; } = default!;
        public PlanLocationStatus Status { get; private set; } = default!;
        private PlanLocation() { }
    }
}
