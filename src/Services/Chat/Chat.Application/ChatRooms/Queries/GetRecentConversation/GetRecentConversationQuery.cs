namespace Chat.Application.ChatRooms.Queries.GetRecentConversation
{
    public record GetRecentConversationQuery(PaginationRequest PaginationRequest, Guid UserId) : IQuery<GetRecentConversationResult>;
    public record GetRecentConversationResult(PaginationResult<GetRecentConversationDto> Conversations);
}
