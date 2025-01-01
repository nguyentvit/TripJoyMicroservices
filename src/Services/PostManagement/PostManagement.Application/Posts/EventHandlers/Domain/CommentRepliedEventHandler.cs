
namespace PostManagement.Application.Posts.EventHandlers.Domain
{
    public class CommentRepliedEventHandler : IDomainEventHandler<CommentRepliedEvent>
    {
        public Task Handle(CommentRepliedEvent notification, CancellationToken cancellationToken)
        {
            var comment = notification.Comment;
            var childCommentId = notification.ChildComment;
            comment.AddChildComment(childCommentId);
            return Task.CompletedTask;
        }
    }
}
