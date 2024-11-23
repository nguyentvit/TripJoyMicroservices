
namespace TravelPlan.Application.Plans.Queries.GetMembersByPlanId
{
    public class GetMembersByPlanIdHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetMembersByPlanIdQuery, GetMembersByPlanIdResult>
    {
        public async Task<GetMembersByPlanIdResult> Handle(GetMembersByPlanIdQuery query, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(query.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);

            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(query.UserId);
            plan.AccessPlan(userId);

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var planMembers = plan.PlanMembers;
            var totalCount = planMembers.Count;

            var result = planMembers
                .Select(p => new PlanMemberResponseDto(p.MemberId.Value, p.Role))
                .OrderBy(p => p.Role)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();

            return new GetMembersByPlanIdResult(new PaginationResult<PlanMemberResponseDto>(
                pageIndex, 
                pageSize, 
                totalCount, 
                result));
        }
    }
}
