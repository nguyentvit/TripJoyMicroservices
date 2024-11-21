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

            var plansQuery = await dbContext.Plans
                .Where(p => p.PlanMembers.Any(m => m.MemberId == userId))
                .ToListAsync(cancellationToken);

            if (!string.IsNullOrEmpty(query.keySearch.Title))
            {
                plansQuery = plansQuery.Where(p => p.Title.Value.ToLower().StartsWith(query.keySearch.Title.ToLower())).ToList();
            }
            if (query.keySearch.StartDate.HasValue)
            {
                plansQuery = plansQuery.Where(p => p.StartDate.Value >= query.keySearch.StartDate.Value).ToList();
            }
            if (query.keySearch.Status.HasValue)
            {
                plansQuery = plansQuery.Where(p => p.Status == query.keySearch.Status.Value).ToList();
            }
            var totalCount = plansQuery.Count;

            var plans = plansQuery
                .OrderByDescending(p => p.StartDate)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            List<PlanResponseDto> result = new();

            foreach (var plan in plans)
            {
                var planDto = await plan.ToPlanResponseDto(dbContext);
                result.Add(planDto);
            }

            return new GetPlansResult(new PaginationResult<PlanResponseDto>(
                pageIndex,
                pageSize,
                totalCount,
                result
                ));
        }
    }
}
