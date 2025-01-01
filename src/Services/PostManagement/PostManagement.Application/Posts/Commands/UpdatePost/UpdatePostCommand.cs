namespace PostManagement.Application.Posts.Commands.UpdatePost
{
    public record UpdatePostCommand(Guid UserId, Guid PostId, UpdatePostDto UpdatedPost) : ICommand<UpdatePostResult>;
    public record UpdatePostResult(bool IsSuccess);
}
