
namespace TravelPlan.Application.PlanLocations.Commands.AddPlanLocationExpense
{
    public class AddPlanLocationExpenseHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<AddPlanLocationExpenseCommand, AddPlanLocationExpenseResult>
    {
        public async Task<AddPlanLocationExpenseResult> Handle(AddPlanLocationExpenseCommand command, CancellationToken cancellationToken)
        {
            var planLocationId = PlanLocationId.Of(command.PlanLocationId);

            var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId], cancellationToken);

            if (planLocation == null)
                throw new PlanLocationNotFoundException(planLocationId.Value);

            var planId = planLocation.PlanId;

            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);

            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var payerId = UserId.Of(command.PlanLocationExpense.PayerId);

            List<UserId> planLocationExpenseIds = new();
            List<UserId> planLocationUserSpenders = new();


            foreach (var planLocationExpenseId in command.PlanLocationExpense.UserSpenderIds)
            {
                planLocationExpenseIds.Add(UserId.Of(planLocationExpenseId.UserId));
                planLocationUserSpenders.Add(UserId.Of(planLocationExpenseId.UserId));
            }

            planLocationExpenseIds.Add(payerId);

            plan.AddPlanLocationExpense(userId, planLocationExpenseIds);

            var amount = Money.Of(command.PlanLocationExpense.Amount);

            planLocation.AddPlanLocationExpense(planLocationUserSpenders, payerId, amount);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new AddPlanLocationExpenseResult(true);
        }
    }
}
