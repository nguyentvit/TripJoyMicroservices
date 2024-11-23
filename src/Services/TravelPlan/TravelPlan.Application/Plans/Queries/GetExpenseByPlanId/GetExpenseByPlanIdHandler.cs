namespace TravelPlan.Application.Plans.Queries.GetExpenseByPlanId
{
    public class GetExpenseByPlanIdHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetExpenseByPlanIdQuery, GetExpenseByPlanIdResult>
    {
        public async Task<GetExpenseByPlanIdResult> Handle(GetExpenseByPlanIdQuery query, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(query.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(query.UserId);

            plan.AccessPlan(userId);

            var planLocationIds = plan.PlanLocationIds;

            decimal expense = 0;

            foreach (var planLocationId in planLocationIds)
            {
                var planLocation = await dbContext.PlanLocations.FindAsync([ planLocationId], cancellationToken);
                if (planLocation == null)
                    throw new PlanLocationNotFoundException(planLocationId.Value);

                if (planLocation.Amount != null)
                    expense += planLocation.Amount.Value;
            }

            return new GetExpenseByPlanIdResult(expense);
        }
    }
}
