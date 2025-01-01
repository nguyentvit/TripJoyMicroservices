using Chat.Domain.ValueObjects;

namespace Chat.Application.ChatRooms.Queries.GetRecentConversation
{
    public class GetRecentConversationHandler
        (IApplicationDbContext dbContext,
        IUserAccessService userService) : IQueryHandler<GetRecentConversationQuery, GetRecentConversationResult>
    {
        public async Task<GetRecentConversationResult> Handle(GetRecentConversationQuery query, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(query.UserId);

            var rooms = await dbContext.ChatRooms.Where(r => r.Members.Any(m => m.MemberId == userId) && r.Type == ChatRoomType.Private && r.ChatMessageIds.Any()).ToListAsync(cancellationToken);

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = rooms.Count;

            List<ChatMessageId> lastMessageIdOfRooms = new();

            foreach (var room in rooms)
            {
                if (room.ChatMessageIds.Any())
                {
                    lastMessageIdOfRooms.Add(room.ChatMessageIds[room.ChatMessageIds.Count - 1]);
                }
            }

            var chatMessages = await dbContext.ChatMessages
                .Where(m => lastMessageIdOfRooms.Contains(m.Id))
                .OrderByDescending(m => m.CreatedBy)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);


            List<GetRecentConversationDto> result = [];
            List<Guid> usersId = [];

            foreach (var chatMessage in chatMessages)
            {
                var chatRoomId = chatMessage.ChatRoomId;
                var chatRoom = rooms.FirstOrDefault(r => r.Id == chatRoomId);
                if (chatRoom == null)
                    throw new ChatRoomNotFoundException(chatRoomId.Value);

                var memberId = chatRoom.Members.Where(m => m.MemberId != userId).Select(m => m.MemberId.Value).ToList();

                if (memberId.Count == 1)
                {
                    usersId.Add(memberId[0]);
                }
            }
            
            var usersInfo = await userService.GetUsersInfoAsync(usersId, cancellationToken);
            foreach (var chatMessage in chatMessages)
            {
                var chatRoomId = chatMessage.ChatRoomId;
                var chatRoom = rooms.FirstOrDefault(r => r.Id == chatRoomId);
                if (chatRoom == null)
                    throw new ChatRoomNotFoundException(chatRoomId.Value);
                var memberId = chatRoom.Members.Where(m => m.MemberId != userId).Select(m => m.MemberId.Value).ToList();
                if (memberId.Count != 1)
                {
                    throw new Exception("In GetRecentConversationHandler");
                }
                var userInfo = usersInfo.FirstOrDefault(user => user.UserId == memberId[0]);
                var conversation = new GetRecentConversationDto(
                    RoomId: chatMessage.ChatRoomId.Value,
                    UserId: userInfo!.UserId,
                    UserName: userInfo.UserName,
                    Avatar: userInfo.Avatar,
                    LastMessage: chatMessage.Message.Value,
                    SendByMe: chatMessage.PostedByUser == userId,
                    IsRead: chatMessage.ReadByRecipients.Any(r => r.ReadByUserId == userId),
                    SendAt: chatMessage.CreatedAt!.Value
                    );

                result.Add(conversation);
            }

            return new GetRecentConversationResult(new PaginationResult<GetRecentConversationDto>(pageIndex, pageSize, totalCount, result));
        }
    }
}
