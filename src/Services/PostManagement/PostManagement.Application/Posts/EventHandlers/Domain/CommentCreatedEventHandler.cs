
namespace PostManagement.Application.Posts.EventHandlers.Domain
{
    public class CommentCreatedEventHandler : IDomainEventHandler<CommentCreatedEvent>
    {
        public Task Handle(CommentCreatedEvent notification, CancellationToken cancellationToken)
        {
            var post = notification.Post;

            var commentId = notification.CommentId;

            post.AddCommentId(commentId);

            return Task.CompletedTask;
        }
    }
}
