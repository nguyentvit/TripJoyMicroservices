
namespace Chat.Application.ChatRooms.Commands.MarkMessageRead
{
    public class MarkMessageReadHandler
        (IApplicationDbContext dbContext) : ICommandHandler<MarkMessageReadCommand, MarkMessageReadResult>
    {
        public async Task<MarkMessageReadResult> Handle(MarkMessageReadCommand command, CancellationToken cancellationToken)
        {
            var chatRoomId = ChatRoomId.Of(command.ChatRoomId);
            var chatRoom = await dbContext.ChatRooms.FindAsync(chatRoomId);
            if (chatRoom == null)
                throw new ChatRoomNotFoundException(chatRoomId.Value);

            var userId = UserId.Of(command.UserId);
            chatRoom.AccessChatRoom(userId);

            var chatMessageIds = chatRoom.ChatMessageIds;
            foreach (var chatMessageId in chatMessageIds)
            {
                var chatMessage = await dbContext.ChatMessages.FindAsync([chatMessageId], cancellationToken);
                if (chatMessage == null)
                    throw new ChatMessageNotFoundException(chatMessageId.Value);

                chatMessage.MarkMessageRead(userId);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return new MarkMessageReadResult(true);
        }
    }
}
