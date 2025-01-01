
namespace TravelPlan.Application.Plans.Queries.GetPlanInvitationByUserId
{
    public class GetPlanInvitationByUserIdHandler
        (IApplicationDbContext dbContext,
        IUserAccessService userService) : IQueryHandler<GetPlanInvitationByUserIdQuery, GetPlanInvitationByUserIdResult>
    {
        public async Task<GetPlanInvitationByUserIdResult> Handle(GetPlanInvitationByUserIdQuery query, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(query.UserId);

            var plansQuery = await dbContext.Plans.Where(p => p.PlanInvitations.Any(i => i.InviteeId == userId)).ToListAsync(cancellationToken);

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = plansQuery.Count;

            var inviterIds = plansQuery
                .Select(p => p.PlanInvitations.First(i => i.InviteeId == userId).InviterId.Value)
                .Distinct()
                .ToList();

            var usersInfo = await userService.GetUsersInfoAsync(inviterIds, cancellationToken);

            var plans = plansQuery
                .Select(p =>
                {
                    var inviterId = p.PlanInvitations.First(i => i.InviteeId == userId).InviterId.Value;
                    var userInfo = usersInfo.FirstOrDefault(u => u.UserId == inviterId);

                    return new PlanInvitationByUserIdDto(
                        PlanId: p.Id.Value,
                        InviterId: inviterId,
                        Title: p.Title.Value,
                        StartDate: p.StartDate.Value,
                        EndDate: p.EndDate.Value,
                        InviterName: userInfo?.UserName ?? "Unknown",
                        InviterAvatar: userInfo?.Avatar ?? null
                    );
                })
                .OrderByDescending(p => p.StartDate)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            return new GetPlanInvitationByUserIdResult(new PaginationResult<PlanInvitationByUserIdDto>
                (pageIndex, pageSize, totalCount, plans));

        }
    }
}
