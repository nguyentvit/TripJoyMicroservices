namespace Chat.Application.ChatRooms.Commands.CreateRoom
{
    public class CreateRoomHandler
        (IApplicationDbContext dbContext) : ICommandHandler<CreateRoomCommand, CreateRoomResult>
    {
        public async Task<CreateRoomResult> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
        {
            var userIdFirst = UserId.Of(command.UserIdFirst);
            var userIdSecond = UserId.Of(command.UserIdSecond);

            var existingChatRoom = await dbContext.ChatRooms
                .Where(r => r.Type == ChatRoomType.Private)
                .Where(r => r.Members.Any(m => m.MemberId == userIdFirst) && r.Members.Any(m => m.MemberId == userIdSecond))
                .FirstOrDefaultAsync(cancellationToken);

            if (existingChatRoom != null)
            {
                return new CreateRoomResult(new CreateRoomDto(
                    RoomId: existingChatRoom.Id.Value,
                    IsNew: false,
                    Type: ChatRoomType.Private,
                    UserIds: new List<Guid> { command.UserIdFirst, command.UserIdSecond }
                    ));
            }

            var memberFirst = ChatRoomMember.Of(userIdFirst);
            var memberSecond = ChatRoomMember.Of(userIdSecond);

            var newRoom = ChatRoom.CreatePrivateRoom(memberFirst, memberSecond);
            dbContext.ChatRooms.Add(newRoom);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateRoomResult(new CreateRoomDto(
                RoomId: newRoom.Id.Value,
                IsNew: true,
                Type: ChatRoomType.Private,
                UserIds: new List<Guid> { command.UserIdFirst, command.UserIdSecond }
                ));
        }
    }
}
