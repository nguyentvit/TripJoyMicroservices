namespace TravelPlan.Application.Plans.Commands.InviteMember
{
    public class InviteMemberHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<InviteMemberCommand, AddMemberResult>
    {
        public async Task<AddMemberResult> Handle(InviteMemberCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var targetUserId = UserId.Of(command.TargetUserId);

            plan.InviteMember(userId, targetUserId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new AddMemberResult(true);
        }
    }
}
