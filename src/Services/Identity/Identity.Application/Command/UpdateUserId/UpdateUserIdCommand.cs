namespace Identity.Application.Command.UpdateUserId
{
    public record UpdateUserIdCommand(string AccountId, Guid UserId) : IRequest<UpdateUserIdResult>;
    public record UpdateUserIdResult(bool IsSuccess);
}
