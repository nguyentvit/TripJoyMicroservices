namespace TravelPlan.Application.Plans.Commands.RemoveMember
{
    public class RemoveMemberHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<RemoveMemberCommand, RemoveMemberResult>
    {
        public async Task<RemoveMemberResult> Handle(RemoveMemberCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);

            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var targetUserId = UserId.Of(command.TargetUserId);

            plan.RemoveMember(userId, targetUserId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new RemoveMemberResult(true);
        }
    }
}
