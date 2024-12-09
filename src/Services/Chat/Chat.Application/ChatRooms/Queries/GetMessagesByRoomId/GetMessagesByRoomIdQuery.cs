namespace Chat.Application.ChatRooms.Queries.GetMessagesByRoomId
{
    public record GetMessagesByRoomIdQuery(PaginationRequest PaginationRequest, Guid RoomId, Guid UserId) : IQuery<GetMessagesByRoomIdResult>;
    public record GetMessagesByRoomIdResult(PaginationResult<GetMessagesByRoomIdDto> Messages);
}
