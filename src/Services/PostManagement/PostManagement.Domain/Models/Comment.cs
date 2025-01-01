namespace PostManagement.Domain.Models
{
    public class Comment : Aggregate<CommentId>
    {
        private readonly List<CommentReaction> _commentReactions = new();
        private readonly List<CommentId> _commentReplyIds = new();
        public IReadOnlyList<CommentReaction> CommentReactions => _commentReactions.AsReadOnly();
        public IReadOnlyList<CommentId> CommentReplyIds => _commentReplyIds.AsReadOnly();
        public UserId UserId { get; private set; } = default!;
        public PostId PostId { get; private set; } = default!;
        public Content Content { get; private set; } = default!;
        public LikeCount LikeCount { get; private set; } = default!;
        public CommentId? ParentCommentId { get; private set; }
        private Comment(CommentId id, UserId userId, PostId postId, Content content, CommentId? parentCommentId = null)
        {
            Id = id;
            UserId = userId;
            PostId = postId;
            Content = content;
            ParentCommentId = parentCommentId;
            LikeCount = LikeCount.Of(0);

        }
        public static Comment CreateComment(UserId userId, Post post, Content content)
        {
            var comment = new Comment(CommentId.Of(Guid.NewGuid()), userId, post.Id, content);

            comment.AddDomainEvent(new CommentCreatedEvent(post, comment.Id));

            return comment;
        }
        public static Comment CreateCommentReply(UserId userId, Post post, Content content, Comment parentComment)
        {
            var comment = new Comment(CommentId.Of(Guid.NewGuid()), userId, post.Id, content, parentComment.Id);

            comment.AddDomainEvent(new CommentCreatedEvent(post, comment.Id));
            comment.AddDomainEvent(new CommentRepliedEvent(parentComment, comment.Id));

            return comment;
        }
        public void AddChildComment(CommentId commentId)
        {
            _commentReplyIds.Add(commentId);
        }
        public void RemoveChildComment(CommentId commentId)
        {
            _commentReplyIds.Remove(commentId);
        }
        public void AddCommentReaction(CommentReaction commentReaction)
        {
            var commentReactionExistedByUserId = _commentReactions.FirstOrDefault(cr => cr.UserId == commentReaction.UserId);
            if (commentReactionExistedByUserId != null)
            {
                if (commentReactionExistedByUserId.Emotion != commentReaction.Emotion)
                    commentReactionExistedByUserId.SetEmotion(commentReaction.Emotion);

            }
            else
            {
                _commentReactions.Add(commentReaction);
                var oldLikeCount = LikeCount.Value;
                LikeCount = LikeCount.Of(++oldLikeCount);
            }
        }
        public void RemoveCommentReactionByUserId(UserId userId)
        {
            var commentReactionExistedByUserId = _commentReactions.FirstOrDefault(cr => cr.UserId == userId);
            if (commentReactionExistedByUserId != null)
            {
                _commentReactions.Remove(commentReactionExistedByUserId);
                var oldLikeCount = LikeCount.Value;
                LikeCount = LikeCount.Of(--oldLikeCount);
            }
        }
        public void UpdateComment(Content content)
        {
            Content = content;
        }
    }
}
