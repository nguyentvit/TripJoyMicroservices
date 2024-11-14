namespace TravelPlan.Application.Plans.Commands.ChangePermission
{
    public class ChangePermissionHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<ChangePermissionCommand, ChangePermissionResult>
    {
        public async Task<ChangePermissionResult> Handle(ChangePermissionCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var targetUserId = UserId.Of(command.TargetUserId);

            plan.ChangePermission(userId, targetUserId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new ChangePermissionResult(true);
        }
    }
}
