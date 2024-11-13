namespace TravelPlan.Domain.Entities
{
    public class PlanInvitation : Entity<PlanInvitationId>
    {
        public UserId InviterId { get; private set; } = default!;
        public UserId InviteeId { get; private set; } = default!;
        private PlanInvitation() { }
        private PlanInvitation(PlanInvitationId id, UserId inviterId, UserId inviteeId)
        {
            Id = id;
            InviteeId = inviteeId;
            InviterId = inviterId;
        }
        public static PlanInvitation Of(UserId inviterId, UserId inviteeId)
        {
            ArgumentNullException.ThrowIfNull(inviteeId);
            ArgumentNullException.ThrowIfNull(inviterId);
            return new PlanInvitation(PlanInvitationId.Of(Guid.NewGuid()), inviterId, inviteeId);
        }
    }
}
