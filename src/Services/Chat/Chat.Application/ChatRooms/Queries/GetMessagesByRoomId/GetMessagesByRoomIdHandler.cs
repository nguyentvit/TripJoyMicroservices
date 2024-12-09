namespace Chat.Application.ChatRooms.Queries.GetMessagesByRoomId
{
    public class GetMessagesByRoomIdHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetMessagesByRoomIdQuery, GetMessagesByRoomIdResult>
    {
        public async Task<GetMessagesByRoomIdResult> Handle(GetMessagesByRoomIdQuery query, CancellationToken cancellationToken)
        {
            var chatRoomId = ChatRoomId.Of(query.RoomId);

            var chatRoom = await dbContext.ChatRooms.FindAsync([chatRoomId], cancellationToken);

            if (chatRoom == null)
                throw new ChatRoomNotFoundException(chatRoomId.Value);

            var userId = UserId.Of(query.UserId);

            chatRoom.AccessChatRoom(userId);

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = chatRoom.Messages.Count;

            var pagedMessages = chatRoom.Messages
                .OrderByDescending(m => m.CreatedAt)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();

            var messagesDto = pagedMessages.Select(m => new GetMessagesByRoomIdDto(
                Message: m.Message.Value,
                PostedByUser: m.PostedByUser.Value,
                PostedAt: m.CreatedAt!.Value
                )).ToList();

            return new GetMessagesByRoomIdResult(new PaginationResult<GetMessagesByRoomIdDto>(pageIndex, pageSize, totalCount, messagesDto));
        }
    }
}
