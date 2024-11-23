namespace TravelPlan.Application.Plans.Queries.GetExpenseMeByPlanId
{
    public class GetExpenseMeByPlanIdHandler
        (IApplicationDbContext dbContext,
        ILocationGrpcService locationGrpcService)
        : IQueryHandler<GetExpenseMeByPlanIdQuery, GetExpenseMeByPlanIdResult>
    {
        public async Task<GetExpenseMeByPlanIdResult> Handle(GetExpenseMeByPlanIdQuery query, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(query.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(query.UserId);

            plan.AccessPlan(userId);

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var planExpenseDto = await plan.ToPlanExpenseDto(userId, query.PaginationRequest, dbContext, locationGrpcService);

            return new GetExpenseMeByPlanIdResult(planExpenseDto.Expense, planExpenseDto.Excess, new PaginationResult<ExpenseResponseDto>(
                pageIndex,
                pageSize,
                planExpenseDto.TotalCount,
                planExpenseDto.DetailExpense
                ));
        }
    }
}
