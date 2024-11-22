namespace TravelPlan.Application.PlanLocations.Queries.GetPlanLocationByPlanId
{
    public class GetPlanLocationByPlanIdHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetPlanLocationByPlanIdQuery, GetPlanLocationByPlanIdResult>
    {
        public async Task<GetPlanLocationByPlanIdResult> Handle(GetPlanLocationByPlanIdQuery query, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(query.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);

            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(query.UserId);

            plan.AccessPlan(userId);
            
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = plan.PlanLocationIds.Count;

            var planLocations = await dbContext.PlanLocations
                .Where(p => p.PlanId == planId)
                .OrderBy(p => p.Order)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .Select(pl => pl.ToPlanLocationResponseDto())
                .ToListAsync(cancellationToken);

            return new GetPlanLocationByPlanIdResult(new PaginationResult<PlanLocationResponseDto>(
                pageIndex,
                pageSize,
                totalCount,
                planLocations
                ));


        }
    }
}
