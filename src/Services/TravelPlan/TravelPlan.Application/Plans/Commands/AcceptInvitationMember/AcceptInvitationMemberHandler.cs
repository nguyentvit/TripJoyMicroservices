namespace TravelPlan.Application.Plans.Commands.AcceptInvitationMember
{
    public class AcceptInvitationMemberHandler
        (IApplicationDbContext dbContext,
        IPublishEndpoint publishEndpoint)
        : ICommandHandler<AcceptInvitationMemberCommand, AcceptInvitationMemberResult>
    {
        public async Task<AcceptInvitationMemberResult> Handle(AcceptInvitationMemberCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);

            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var estimatedStartDate = plan.StartDate;
            var estimatedEndDate = plan.EndDate;

            var userId = UserId.Of(command.UserId);

            var plansExisted = await dbContext.Plans.Where(p => p.PlanMembers.Any(m => m.MemberId == userId)).ToListAsync(cancellationToken);

            foreach (var planExisted in plansExisted)
            {
                if (!(estimatedEndDate.Value.Date < planExisted.StartDate.Value || estimatedStartDate.Value.Date > planExisted.EndDate.Value))
                    throw new Exception($"You are already in other plan in this time {planExisted.Id.Value}");
            }

            plan.AcceptInvitationMember(userId);
            await dbContext.SaveChangesAsync(cancellationToken);

            var eventMessage = new PlanMemberAddedEvent
            {
                PlanId = planId.Value,
                UserId = userId.Value
            };

            await publishEndpoint.Publish(eventMessage, cancellationToken);

            return new AcceptInvitationMemberResult(true);
        }
    }
}
