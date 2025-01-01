namespace TravelPlan.Application.Plans.Queries.GetExpenseMembersByPlanId
{
    public class GetExpenseMembersByPlanIdHandler
        (IApplicationDbContext dbContext, IUserAccessService userService)
        : IQueryHandler<GetExpenseMembersByPlanIdQuery, GetExpenseMembersByPlanIdResult>
    {
        public async Task<GetExpenseMembersByPlanIdResult> Handle(GetExpenseMembersByPlanIdQuery query, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(query.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(query.UserId);

            plan.AccessPlan(userId);

            var planLocationIds = plan.PlanLocationIds;
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var planMembers = plan.PlanMembers;
            var totalCount = planMembers.Count;

            var planMembersPagination = planMembers
                .OrderBy(p => p.Role)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();

            var userExpenses = new Dictionary<UserId, decimal>();
            foreach (var member in planMembersPagination)
            {
                userExpenses.Add(member.MemberId, 0);
            }

            foreach (var planLocationId in planLocationIds)
            {
                var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId]);
                if (planLocation == null)
                    throw new PlanLocationNotFoundException(planLocationId.Value);

                decimal amount = 0;

                if (planLocation.Amount != null && planLocation.PlanLocationUserSpenders.Count > 0)
                {
                    amount = (planLocation.Amount.Value / planLocation.PlanLocationUserSpenders.Count);
                }

                foreach (var planExpenseMemberId in userExpenses.Keys.ToList())
                {
                    if (planLocation.PlanLocationUserSpenders.Any(u => u.UserSpenderId == planExpenseMemberId))
                        userExpenses[planExpenseMemberId] -= amount;

                    if (planLocation.PayerId == planExpenseMemberId)
                        userExpenses[planExpenseMemberId] += (amount * (planLocation.PlanLocationUserSpenders.Count));
                }
            }

            List<PlanExpenseMembersResponseDto> result = new();

            var userIds = userExpenses.Keys.Select(u => u.Value).Distinct().ToList();
            var usersInfo = await userService.GetUsersInfoAsync(userIds);

            foreach (var planExpenseMemberId in userExpenses.Keys.ToList())
            {
                var userInfo = usersInfo.FirstOrDefault(u => u.UserId == planExpenseMemberId.Value);
                result.Add(new PlanExpenseMembersResponseDto(planExpenseMemberId.Value, userExpenses[planExpenseMemberId], userInfo!.UserName, userInfo.Avatar));
            }

            return new GetExpenseMembersByPlanIdResult(new PaginationResult<PlanExpenseMembersResponseDto>(pageIndex, pageSize, totalCount, result));
        }
    }
}
