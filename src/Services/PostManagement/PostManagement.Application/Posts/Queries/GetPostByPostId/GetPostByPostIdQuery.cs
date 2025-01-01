namespace PostManagement.Application.Posts.Queries.GetPostByPostId
{
    public record GetPostByPostIdQuery(Guid UserId, Guid PostId) : IQuery<GetPostByPostIdResult>;
    public record GetPostByPostIdResult(GetPostDto Post);
}
