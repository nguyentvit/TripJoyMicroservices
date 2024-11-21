using TravelPlan.Application.Extensions;

namespace TravelPlan.Application.Plans.Queries.GetPlans
{
    public class GetPlansHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetPlansQuery, GetPlansResult>
    {
        public async Task<GetPlansResult> Handle(GetPlansQuery query, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(query.UserId);
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Plans
                .Where(p => p.PlanMembers.Any(m => m.MemberId == userId))
                .CountAsync(cancellationToken);

            var plans = await dbContext.Plans
                .Where(p => p.PlanMembers.Any(m => m.MemberId == userId))
                .OrderByDescending(p => p.CreatedAt)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var responsePlan = plans.Select(p => p.ToPlanResponseDto()).ToList();

            return new GetPlansResult(new PaginationResult<PlanResponseDto>(
                pageIndex,
                pageSize,
                totalCount,
                responsePlan
                ));
        }
    }
}
