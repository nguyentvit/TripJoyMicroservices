
namespace TravelPlan.Application.Plans.Queries.GetUsersAvailableAddMember
{
    public class GetUsersAvailableAddMemberHandler
        (IApplicationDbContext dbContext,
        IUserAccessService userService) : IQueryHandler<GetUsersAvailableAddMemberQuery, GetUsersAvailableAddMemberResult>
    {
        public async Task<GetUsersAvailableAddMemberResult> Handle(GetUsersAvailableAddMemberQuery query, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(query.PlanId);

            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(query.UserId);

            plan.AccessPlan(userId);

            var users = await userService.GetAllUsersAsync(query.PaginationRequest, new BuildingBlocks.Dtos.KeySearchUser(query.KeySearch.Name), cancellationToken);

            var usersSearch = users.Data;

            var memberIds = plan.PlanMembers.Select(p => p.MemberId.Value).ToList();
            var inviteeIds = plan.PlanInvitations.Select(p => p.InviteeId.Value).ToList();
            var applyIds = plan.PlanJoinRequests.Select(p => p.UserId.Value).ToList();

            List<PlanInvitationUserAvailableDto> usersResult = new();

            foreach (var user in usersSearch)
            {
                InvitationStatus status = InvitationStatus.NotInvited;

                if (memberIds.Contains(user.UserId))
                {
                    status = InvitationStatus.Joined;
                }
                else if (inviteeIds.Contains(user.UserId))
                {
                    status = InvitationStatus.Invited;
                }
                else if (user.UserId == userId.Value)
                {
                    status = InvitationStatus.Self;
                }
                else if (applyIds.Contains(user.UserId))
                {
                    status = InvitationStatus.Applied;
                }
                usersResult.Add(new PlanInvitationUserAvailableDto(
                    UserId: user.UserId,
                    UserName: user.UserName,
                    Avatar: user.Avatar,
                    Status: status
                    ));
            }

            return new GetUsersAvailableAddMemberResult(new PaginationResult<PlanInvitationUserAvailableDto>(
                users.PageIndex,
                users.PageSize,
                users.Count,
                usersResult
                ));
        }
    }
}
