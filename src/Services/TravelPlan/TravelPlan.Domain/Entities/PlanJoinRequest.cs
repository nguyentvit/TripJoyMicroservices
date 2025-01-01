namespace TravelPlan.Domain.Entities
{
    public class PlanJoinRequest : Entity<PlanJoinRequestId>
    {
        public UserId UserId { get; private set; } = default!;
        public Introduction Introduction { get; private set; } = default!;
        private PlanJoinRequest() { }
        private PlanJoinRequest(PlanJoinRequestId id, UserId userId, Introduction introduction)
        {
            Id = id;
            UserId = userId;
            Introduction = introduction;
        }
        public static PlanJoinRequest Of(UserId userId, Introduction introduction)
        {
            return new PlanJoinRequest(PlanJoinRequestId.Of(Guid.NewGuid()), userId, introduction);
        }
        public void UpdateIntroduction(Introduction introduction)
        {
            Introduction = introduction;
        }
    }
}
