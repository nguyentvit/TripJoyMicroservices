namespace TravelPlan.Application.Plans.Commands.DeclineInvitationMember
{
    public class DeclineInvitationMemberHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<DeclineInvitationMemberCommand, DeclineInvitationMemberResult>
    {
        public async Task<DeclineInvitationMemberResult> Handle(DeclineInvitationMemberCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);
            
            var userId = UserId.Of(command.UserId);

            plan.DeclineInvitationMember(userId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeclineInvitationMemberResult(true);
        }
    }
}
