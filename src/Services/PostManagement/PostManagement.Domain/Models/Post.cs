namespace PostManagement.Domain.Models
{
    public class Post : Aggregate<PostId>
    {
        private readonly List<PostReaction> _postReactions = new();
        private readonly List<CommentId> _commentIds = new();
        private readonly List<PostImage> _postImages = new();
        public IReadOnlyList<PostReaction> PostReactions => _postReactions.AsReadOnly();
        public IReadOnlyList<CommentId> CommentIds => _commentIds.AsReadOnly();
        public IReadOnlyList<PostImage> PostImages => _postImages.AsReadOnly();
        public UserId UserId { get; private set; } = default!;
        public Content Content { get; private set; } = default!;
        public LikeCount LikeCount { get; private set; } = default!;
        public PostType PostType { get; private set; } = default!;
        protected Post() { }
        protected Post(PostId id, UserId userId, Content content, PostType postType, List<FileImg>? images)
        {
            Id = id;
            UserId = userId;
            Content = content;
            LikeCount = LikeCount.Of(0);
            PostType = postType;

            if (images is not null && images.Count > 0)
            {
                AddDomainEvent(new AddImagesEvent(this, images));
            }
        }
        public static Post CreatePost(UserId userId, Content content, List<FileImg>? images)
        {
            var post = new Post(PostId.Of(Guid.NewGuid()), userId, content, PostType.Normal, images);

            return post;
        }
        public void AddPostImage(PostImage postImage)
        {
            _postImages.Add(postImage);
        }
        public void AddPostReaction(PostReaction postReaction)
        {
            var postReactionExistedByUserId = _postReactions.FirstOrDefault(pr => pr.UserId == postReaction.UserId);
            if (postReactionExistedByUserId != null)
            {
                if (postReactionExistedByUserId.Emotion != postReaction.Emotion)
                    postReactionExistedByUserId.SetEmotion(postReaction.Emotion);
            }
            else
            {
                _postReactions.Add(postReaction);
                var oldLikeCount = LikeCount.Value;
                LikeCount = LikeCount.Of(++oldLikeCount);
            }
        }
        public void RemovePostReactionByUserId(UserId userId)
        {
            var postReactionExistedByUserId = _postReactions.FirstOrDefault(pr => pr.UserId == userId);
            if (postReactionExistedByUserId != null)
            {
                _postReactions.Remove(postReactionExistedByUserId);
                var oldLikeCount = LikeCount.Value;
                LikeCount = LikeCount.Of(--oldLikeCount);
            }
        }
        public void AddCommentId(CommentId commentId)
        {
            _commentIds.Add(commentId);
        }
        public void RemoveCommentId(CommentId commentId)
        {
            _commentIds.Remove(commentId);
        }
        public void UpdatePost(Content content, List<FileImg>? images)
        {
            AddDomainEvent(new PostUpdatedEvent(this, _postImages, images));

            Content = content;
            _postImages.Clear();
        }
    }
}
