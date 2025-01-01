
namespace TravelPlan.Application.Plans.Commands.JoinRequestPlan
{
    public class JoinRequestPlanHandler
        (IApplicationDbContext dbContext) : ICommandHandler<JoinRequestPlanCommand, JoinRequestPlanResult>
    {
        public async Task<JoinRequestPlanResult> Handle(JoinRequestPlanCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var introduction = Introduction.Of(command.Introduction);

            var joinRequest = PlanJoinRequest.Of(userId, introduction);
            plan.JoinRequestPlan(joinRequest);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new JoinRequestPlanResult(true);
        }
    }
}
