namespace PostManagement.Application.Posts.Commands.RevokeLikePost
{
    public record RevokeLikePostCommand(Guid PostId, Guid UserId) : ICommand<RevokeLikePostResult>;
    public record RevokeLikePostResult(bool IsSuccess);
}
