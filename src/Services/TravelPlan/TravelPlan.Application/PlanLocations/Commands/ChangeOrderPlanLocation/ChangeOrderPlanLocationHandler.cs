namespace TravelPlan.Application.PlanLocations.Commands.ChangeOrderPlanLocation
{
    public class ChangeOrderPlanLocationHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<ChangeOrderPlanLocationCommand, ChangeOrderPlanLocationResult>
    {
        public async Task<ChangeOrderPlanLocationResult> Handle(ChangeOrderPlanLocationCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            plan.ChangeOrderPlanLocation(userId);

            var planLocationIdFirst = PlanLocationId.Of(command.PlanLocationIdFirst);
            var planLocationIdSecond = PlanLocationId.Of(command.PlanLocationIdSecond);
            
            var idsToCheck = new[] { planLocationIdFirst, planLocationIdSecond };
            if (!idsToCheck.All(id => plan.PlanLocationIds.Contains(id)))
                throw new Exception("One or both two is not in plan");

            var planLocationFirst = await dbContext.PlanLocations.FindAsync([planLocationIdFirst], cancellationToken);
            if (planLocationFirst == null)
                throw new PlanLocationNotFoundException(planLocationIdFirst.Value);

            var planLocationSecond = await dbContext.PlanLocations.FindAsync([planLocationIdSecond], cancellationToken);
            if (planLocationSecond == null)
                throw new PlanLocationNotFoundException(planLocationIdSecond.Value);

            var orderFirst = planLocationFirst.Order;
            var orderSecond = planLocationSecond.Order;

            var dateFirst = planLocationFirst.EstimatedStartDate;
            var dateSecond = planLocationSecond.EstimatedStartDate;

            planLocationFirst.ChangeOrderAndDate(orderSecond, dateSecond);
            planLocationSecond.ChangeOrderAndDate(orderFirst, dateFirst);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new ChangeOrderPlanLocationResult(true);
        }
    }
}
