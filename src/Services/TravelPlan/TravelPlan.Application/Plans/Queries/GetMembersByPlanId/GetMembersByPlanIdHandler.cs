
namespace TravelPlan.Application.Plans.Queries.GetMembersByPlanId
{
    public class GetMembersByPlanIdHandler
        (IApplicationDbContext dbContext,
        IUserAccessService userService)
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

            var userIds = planMembers.Select(x => x.MemberId.Value).Distinct().ToList();
            var usersInfo = await userService.GetUsersInfoAsync(userIds, cancellationToken);

            var result = planMembers
                .Select(p =>
                {
                    var userId = p.MemberId.Value;
                    var userInfo = usersInfo.FirstOrDefault(u => u.UserId == userId);

                    return new PlanMemberResponseDto(userId, p.Role, userInfo!.UserName, userInfo.Avatar);
                })
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
