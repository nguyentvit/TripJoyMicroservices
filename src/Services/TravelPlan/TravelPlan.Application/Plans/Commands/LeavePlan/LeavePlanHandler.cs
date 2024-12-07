namespace TravelPlan.Application.Plans.Commands.LeavePlan
{
    public class LeavePlanHandler
        (IApplicationDbContext dbContext,
        IPublishEndpoint publishEndpoint)
        : ICommandHandler<LeavePlanCommand, LeavePlanResult>
    {
        public async Task<LeavePlanResult> Handle(LeavePlanCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);

            var planLocationIds = plan.PlanLocationIds;
            foreach (var planLocationId in planLocationIds)
            {
                var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId], cancellationToken);
                if (planLocation == null)
                    throw new PlanLocationNotFoundException(planLocationId.Value);

                if (planLocation.PlanLocationUserSpenders.Any(userSpender => userSpender.UserSpenderId == userId) || planLocation.PayerId == userId)
                    throw new Exception($"User is in plan location user spender or is a payer {planLocationId.Value}");
            }

            plan.LeavePlan(userId);
            await dbContext.SaveChangesAsync(cancellationToken);

            var eventMessage = new PlanMemberRemovedEvent
            {
                PlanId = planId.Value,
                UserId = userId.Value
            };

            await publishEndpoint.Publish(eventMessage, cancellationToken);

            return new LeavePlanResult(true);
        }
    }
}
