namespace TravelPlan.Application.Plans.Commands.AddMember
{
    public class AddMemberHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<AddMemberCommand, AddMemberResult>
    {
        public async Task<AddMemberResult> Handle(AddMemberCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var targetUserId = UserId.Of(command.TargetUserId);

            plan.AddMember(userId, targetUserId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new AddMemberResult(true);
        }
    }
}
