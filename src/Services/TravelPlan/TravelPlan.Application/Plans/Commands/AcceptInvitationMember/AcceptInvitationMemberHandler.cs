namespace TravelPlan.Application.Plans.Commands.AcceptInvitationMember
{
    public class AcceptInvitationMemberHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<AcceptInvitationMemberCommand, AcceptInvitationMemberResult>
    {
        public async Task<AcceptInvitationMemberResult> Handle(AcceptInvitationMemberCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);

            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);

            plan.AcceptInvitationMember(userId);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new AcceptInvitationMemberResult(true);
        }
    }
}
