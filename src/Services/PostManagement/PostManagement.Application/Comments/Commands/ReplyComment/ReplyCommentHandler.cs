
namespace PostManagement.Application.Comments.Commands.ReplyComment
{
    public class ReplyCommentHandler
        (IApplicationDbContext dbContext) : ICommandHandler<ReplyCommentCommand, ReplyCommentResult>
    {
        public async Task<ReplyCommentResult> Handle(ReplyCommentCommand command, CancellationToken cancellationToken)
        {
            var commentId = CommentId.Of(command.CommentId);
            var comment = await dbContext.Comments.FindAsync([commentId], cancellationToken);
            if (comment == null)
                throw new CommentNotFoundException(commentId.Value);

            var post = await dbContext.Posts.FindAsync([comment.PostId], cancellationToken);
            if (post == null)
                throw new PostNotFoundException(comment.PostId.Value);

            var userId = UserId.Of(command.UserId);
            var content = Content.Of(command.Comment.Content);

            var commentReply = Comment.CreateCommentReply(userId, post, content, comment);
            dbContext.Comments.Add(commentReply);

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ReplyCommentResult(commentReply.Id.Value);
        }
    }
}
