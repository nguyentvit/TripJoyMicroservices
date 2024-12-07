namespace TravelPlan.Application.Plans.Commands.RemoveMember
{
    public class RemoveMemberHandler
        (IApplicationDbContext dbContext,
        IPublishEndpoint publishEndpoint)
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

            var planLocationIds = plan.PlanLocationIds;
            foreach (var planLocationId in planLocationIds)
            {
                var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId], cancellationToken);
                if (planLocation == null)
                    throw new PlanLocationNotFoundException(planLocationId.Value);

                if (planLocation.PlanLocationUserSpenders.Any(userSpender => userSpender.UserSpenderId == targetUserId) || planLocation.PayerId == targetUserId)
                    throw new Exception($"User is in plan location user spender or is a payer {planLocationId.Value}");
            }

            plan.RemoveMember(userId, targetUserId);
            await dbContext.SaveChangesAsync(cancellationToken);

            var eventMessage = new PlanMemberRemovedEvent
            {
                PlanId = planId.Value,
                UserId = targetUserId.Value
            };

            await publishEndpoint.Publish(eventMessage, cancellationToken);

            return new RemoveMemberResult(true);
        }
    }
}
