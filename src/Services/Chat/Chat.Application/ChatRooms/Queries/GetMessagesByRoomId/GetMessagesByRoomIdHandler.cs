namespace Chat.Application.ChatRooms.Queries.GetMessagesByRoomId
{
    public class GetMessagesByRoomIdHandler
        (IApplicationDbContext dbContext, IUserAccessService userService)
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
            var totalCount = chatRoom.ChatMessageIds.Count;

            var chatMessages = await dbContext.ChatMessages
                .Where(m => m.ChatRoomId == chatRoomId)
                .OrderByDescending(m => m.CreatedAt)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .Select(m => new GetMessagesByRoomIdDto(m.Message.Value, m.PostedByUser.Value, m.CreatedAt!.Value, m.PostedByUser == userId))
                .ToListAsync(cancellationToken);

            var userIds = chatRoom.Members.Select(m => m.MemberId.Value).Distinct().ToList();
            var usersInfo = await userService.GetUsersInfoAsync(userIds, cancellationToken);

            var members = usersInfo.Select(u => new GetMessagesByRoomIdMemberDto(u.UserId, u.UserName, u.Avatar)).ToList();

            return new GetMessagesByRoomIdResult(new PaginationResult<GetMessagesByRoomIdDto>(pageIndex, pageSize, totalCount, chatMessages), members);
        }
    }
}
