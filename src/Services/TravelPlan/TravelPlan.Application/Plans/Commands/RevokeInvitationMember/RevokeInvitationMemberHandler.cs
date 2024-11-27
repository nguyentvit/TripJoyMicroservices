
namespace TravelPlan.Application.Plans.Commands.RevokeInvitationMember
{
    public class RevokeInvitationMemberHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<RevokeInvitationMemberCommand, RevokeInvitationMemberResult>
    {
        public async Task<RevokeInvitationMemberResult> Handle(RevokeInvitationMemberCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var targetUserId = UserId.Of(command.TargetUserId);

            plan.RevokeInvitationMember(userId, targetUserId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new RevokeInvitationMemberResult(true);
        }
    }
}
