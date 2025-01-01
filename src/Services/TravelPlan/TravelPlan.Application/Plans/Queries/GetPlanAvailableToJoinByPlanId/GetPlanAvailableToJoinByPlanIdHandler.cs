namespace TravelPlan.Application.Plans.Queries.GetPlanAvailableToJoinByPlanId
{
    public class GetPlanAvailableToJoinByPlanIdHandler
        (IApplicationDbContext dbContext, IUserAccessService userService, ILocationGrpcService grpcService) : IQueryHandler<GetPlanAvailableToJoinByPlanIdQuery, GetPlanAvailableToJoinByPlanIdResult>
    {
        public async Task<GetPlanAvailableToJoinByPlanIdResult> Handle(GetPlanAvailableToJoinByPlanIdQuery query, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(query.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);
            if (plan.JoinStatus == PlanJoinStatus.NotAllow)
                throw new Exception("Join status with plan is not allow");

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = plan.PlanLocationIds.Count;

            var userId = UserId.Of(query.UserId);

            var userIds = plan.PlanMembers.Where(m => m.Role == MemberRole.Lead).Select(m => m.MemberId.Value).ToList();
            var usersInfo = await userService.GetUsersInfoAsync(userIds, cancellationToken);

            var leadUserInfo = usersInfo.FirstOrDefault();

            var planLocations = await dbContext.PlanLocations
                .Where(p => p.PlanId == planId)
                .OrderBy(p => p.Order)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var planLocationsResult = new List<GetPlanAvailableToJoinByPlanIdDto>();
            
            foreach (var planLocation in planLocations)
            {
                var planLocationResult = await planLocation.ToGetPlanAvailableToJoinByPlanIdDto(grpcService);
                planLocationsResult.Add(planLocationResult);
            }
            var planResult = await plan.ToGetPlanAvailableToJoinByPlanIdDtoPlan(dbContext, userId);
            var leadUserResult = new GetPlanAvailableToJoinByPlanIdDtoPlanLeadUser(leadUserInfo!.UserId, leadUserInfo.UserName, leadUserInfo.Avatar);

            return new GetPlanAvailableToJoinByPlanIdResult(new PaginationResult<GetPlanAvailableToJoinByPlanIdDto>(pageIndex, pageSize, totalCount, planLocationsResult), planResult, leadUserResult);
        }
    }
}
