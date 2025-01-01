
namespace TravelPlan.Application.Plans.Queries.GetJoinPlanRequests
{
    public class GetJoinPlanRequestsHandler
        (IApplicationDbContext dbContext, IUserAccessService userService) : IQueryHandler<GetJoinPlanRequestsQuery, GetJoinPlanRequestsResult>
    {
        public async Task<GetJoinPlanRequestsResult> Handle(GetJoinPlanRequestsQuery query, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(query.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(query.UserId);
            plan.AccessPlan(userId);

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = plan.PlanJoinRequests.Count;

            var planJoinRequests = plan.PlanJoinRequests.OrderByDescending(j => j.CreatedAt).Skip(pageIndex * pageSize).Take(pageSize).ToList();

            var userIds = planJoinRequests.Select(j => j.UserId.Value).ToList();
            var userInfos = await userService.GetUsersInfoAsync(userIds);

            var planJoinRequestsResult = planJoinRequests.Select(j =>
            {
                var userInfo = userInfos.FirstOrDefault(u => u.UserId == j.UserId.Value);
                return new GetJoinPlanRequestsDto(
                    UserId: j.UserId.Value,
                    UserName: userInfo!.UserName,
                    Avatar: userInfo.Avatar,
                    AppliedAt: j.CreatedAt,
                    Introduction: j.Introduction.Value
                    );
            }).ToList();

            return new GetJoinPlanRequestsResult(new PaginationResult<GetJoinPlanRequestsDto>(pageIndex, pageSize, totalCount, planJoinRequestsResult));
        }
    }
}
