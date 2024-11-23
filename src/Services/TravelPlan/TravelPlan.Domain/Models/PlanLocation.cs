namespace TravelPlan.Domain.Models
{
    public class PlanLocation : Aggregate<PlanLocationId>
    {
        private readonly List<PlanLocationImage> _images = new();
        private readonly List<PlanLocationUserSpender> _planLocationUserSpenders = new();
        public IReadOnlyList<PlanLocationImage> Images => _images.AsReadOnly();
        public IReadOnlyList<PlanLocationUserSpender> PlanLocationUserSpenders => _planLocationUserSpenders.AsReadOnly();
        public LocationId LocationId { get; private set; } = default!;
        public Coordinates Coordinates { get; private set; } = default!;
        public PlanId PlanId { get; private set; } = default!;
        public Note Note { get; private set; } = default!;
        public PlanLocationOrder Order { get; private set; } = default!;
        public PlanLocationStatus Status { get; private set; } = default!;
        public UserId? PayerId { get; private set; }
        public Money? Amount { get; private set; }
        private PlanLocation() { }
        private PlanLocation(
            PlanLocationId id,
            PlanId planId,
            LocationId locationId,
            Coordinates coordinates,
            PlanLocationOrder order
            )
        {
            Id = id;
            PlanId = planId;
            LocationId = locationId;
            Coordinates = coordinates;
            Order = order;
            Status = PlanLocationStatus.NotStarted;
            Note = Note.Of(string.Empty);
        }
        public static PlanLocation Of(PlanId planId, LocationId locationId, Coordinates coordinates, PlanLocationOrder order)
        {
            return new PlanLocation(
                id: PlanLocationId.Of(Guid.NewGuid()),
                planId: planId,
                locationId: locationId,
                coordinates: coordinates,
                order: order
                );
        }
        public void ChangeOrder(PlanLocationOrder order)
        {
            Order = order;
        }
        public void AddPlanLocationExpense(List<UserId> planLocationUserSpenders, UserId payerId, Money amount)
        {
            _planLocationUserSpenders.Clear();
            foreach (var planLocationUserSpender in  planLocationUserSpenders)
            {
                _planLocationUserSpenders.Add(PlanLocationUserSpender.Of(planLocationUserSpender));
            }

            PayerId = payerId;
            Amount = amount;
        }
        public bool ExistUserIdInUserSpender(UserId userId)
        {
            return _planLocationUserSpenders.Any(spender => spender.UserSpenderId == userId);
        }
    }
}
