
namespace TravelPlan.Application.Plans.Queries.GetPlansAvailableToJoin
{
    public class GetPlansAvailableToJoinHandler
        (IApplicationDbContext dbContext) : IQueryHandler<GetPlansAvailableToJoinQuery, GetPlansAvailableToJoinResult>
    {
        public async Task<GetPlansAvailableToJoinResult> Handle(GetPlansAvailableToJoinQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var userId = UserId.Of(query.UserId);

            var plans = await dbContext.Plans.Where(p => p.JoinStatus == PlanJoinStatus.Allow && !p.PlanMembers.Any(m => m.MemberId == userId) && !p.PlanInvitations.Any(i => i.InviteeId == userId)).ToListAsync(cancellationToken);

            var totalCount = plans.Count;

            var plansAvailable = plans.OrderByDescending(p => p.StartDate.Value).Skip(pageIndex * pageSize).Take(pageSize).ToList();

            List<GetPlansAvailableToJoinDto> plansResult = [];
            foreach (var plan in plansAvailable)
            {
                var planAvailable = await plan.ToGetPlansAvailableToJoinDto(dbContext, userId);
                plansResult.Add(planAvailable);
            }

            return new GetPlansAvailableToJoinResult(new PaginationResult<GetPlansAvailableToJoinDto>(pageIndex, pageSize, totalCount, plansResult));
        }
    }
}
