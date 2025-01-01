namespace PostManagement.Application.Posts.Commands.RemovePost
{
    public record RemovePostCommand(Guid PostId, Guid UserId) : ICommand<RemovePostResult>;
    public record RemovePostResult(bool IsSuccess);
}
