namespace TravelPlan.Domain.Entities
{
    public class PlanLocationUserSpender : Entity<PlanLocationUserSpenderId>
    {
        public UserId UserSpenderId { get; private set; } = default!;
        private PlanLocationUserSpender(PlanLocationUserSpenderId id, UserId userSpenderId)
        {
            Id = id;
            UserSpenderId = userSpenderId;
        }
        private PlanLocationUserSpender() { }
        public static PlanLocationUserSpender Of(UserId userSpenderId)
        {
            ArgumentNullException.ThrowIfNull(userSpenderId);
            return new PlanLocationUserSpender(PlanLocationUserSpenderId.Of(Guid.NewGuid()), userSpenderId);
        }
    }
}
