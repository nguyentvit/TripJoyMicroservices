namespace TravelPlan.Application.Plans.Queries.GetExpenseMemberByPlanId
{
    public class GetExpenseMemberByPlanIdHandler
        (IApplicationDbContext dbContext,
        ILocationGrpcService locationGrpcService
        ) : IQueryHandler<GetExpenseMemberByPlanIdQuery, GetExpenseMemberByPlanIdQueryResult>
    {
        public async Task<GetExpenseMemberByPlanIdQueryResult> Handle(GetExpenseMemberByPlanIdQuery query, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(query.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(query.UserId);
            var targetUserId = UserId.Of(query.TargetUserId);

            plan.AccessPlan(userId);

            if (!plan.PlanMembers.Any(pm => pm.MemberId == targetUserId))
                throw new Exception($"{targetUserId.Value} is not in the plan");

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var planExpenseDto = await plan.ToPlanExpenseDto(targetUserId, query.PaginationRequest, dbContext, locationGrpcService);

            return new GetExpenseMemberByPlanIdQueryResult(targetUserId.Value, planExpenseDto.Expense, planExpenseDto.Excess, new PaginationResult<ExpenseResponseDto>(
                pageIndex,
                pageSize,
                planExpenseDto.TotalCount,
                planExpenseDto.DetailExpense
                ));
        }
    }
}
