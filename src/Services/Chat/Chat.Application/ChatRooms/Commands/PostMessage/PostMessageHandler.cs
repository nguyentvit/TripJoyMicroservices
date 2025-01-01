namespace Chat.Application.ChatRooms.Commands.PostMessage
{
    public class PostMessageHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<PostMessageCommand, PostMessageResult>
    {
        public async Task<PostMessageResult> Handle(PostMessageCommand command, CancellationToken cancellationToken)
        {
            var chatRoomId = ChatRoomId.Of(command.RoomId);
            var chatRoom = await dbContext.ChatRooms.FindAsync([chatRoomId], cancellationToken);

            if (chatRoom == null)
                throw new ChatRoomNotFoundException(chatRoomId.Value);

            var userId = UserId.Of(command.UserId);
            chatRoom.AccessChatRoom(userId);

            var message = Message.Of(command.Message);
            var chatMessage = ChatMessage.Of(message, userId, chatRoom);

            dbContext.ChatMessages.Add(chatMessage);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new PostMessageResult(true);
        }
    }
}
