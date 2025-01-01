
namespace Chat.Application.ChatRooms.Commands.CreatePlanRoom
{
    public class CreatePlanRoomHandler
        (IApplicationDbContext dbContext,
        IUserAccessService userService) : ICommandHandler<CreatePlanRoomCommand, CreatePlanRoomResult>
    {
        public async Task<CreatePlanRoomResult> Handle(CreatePlanRoomCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);

            var existingChatRoom = await dbContext.ChatRooms
                .Where(r => r.Type == ChatRoomType.Plan)
                .Where(r => r.PlanId == planId)
                .FirstOrDefaultAsync(cancellationToken);

            var userId = UserId.Of(command.UserId);

            if (existingChatRoom != null)
            {
                if (!existingChatRoom.Members.Any(m => m.MemberId == userId))
                {
                    var newMember = ChatRoomMember.Of(userId);
                    existingChatRoom.AddMember(newMember);

                    await dbContext.SaveChangesAsync(cancellationToken);
                }

                var memberIds = existingChatRoom.Members.Select(m => m.MemberId.Value).ToList();
                var usersInfo = await userService.GetUsersInfoAsync(memberIds, cancellationToken);

                var users = usersInfo.Select(u => new CreatePlanRoomUserInfoDto(
                    UserId: u.UserId,
                    UserName: u.UserName,
                    Avatar: u.Avatar
                    )).ToList();

                return new CreatePlanRoomResult(new CreatePlanRoomDto(
                    RoomId: existingChatRoom.Id.Value,
                    PlanId: planId.Value,
                    IsNew: false,
                    Type: ChatRoomType.Plan,
                    ChatRoomName: (existingChatRoom.Name == null) ? command.ChatRoomName : existingChatRoom.Name.Value,
                    Users: users
                    ));
            }

            var chatRoomName = ChatRoomName.Of(command.ChatRoomName);
            var creatorUser = ChatRoomMember.Of(userId);

            var newRoom = ChatRoom.CreatePlanRoom(planId, chatRoomName, creatorUser);
            dbContext.ChatRooms.Add(newRoom);

            await dbContext.SaveChangesAsync(cancellationToken);

            var memberId = newRoom.Members.Select(m => m.MemberId.Value).ToList();
            var userInfo = await userService.GetUsersInfoAsync(memberId, cancellationToken);

            var user = userInfo.Select(u => new CreatePlanRoomUserInfoDto(
                UserId: u.UserId,
                UserName: u.UserName,
                Avatar: u.Avatar
                )).ToList();

            return new CreatePlanRoomResult(new CreatePlanRoomDto(
                    RoomId: newRoom.Id.Value,
                    PlanId: planId.Value,
                    IsNew: false,
                    Type: ChatRoomType.Plan,
                    ChatRoomName: chatRoomName.Value,
                    Users: user
                    ));
        }
    }
}
