using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostManagement.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            ConfigureCommentTable(builder);
            ConfigureCommentCommentReactionTable(builder);
            ConfigurePostRelation(builder);
            ConfigureCommentCommentReplyTable(builder);
        }
        private void ConfigureCommentTable(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasConversion(
                id => id.Value,
                dbId => CommentId.Of(dbId)
                );

            builder.Property(c => c.UserId)
                .HasConversion(
                userId => userId.Value,
                dbUserId => UserId.Of(dbUserId)
                );

            builder.Property(c => c.Content)
                .HasConversion(
                content => content.Value,
                dbContent => Content.Of(dbContent)
                );

            builder.Property(c => c.LikeCount)
                .HasConversion(
                likeCount => likeCount.Value,
                dbLikeCount => LikeCount.Of(dbLikeCount));

            builder.Property(c => c.ParentCommentId)
                .HasConversion(
                parentCommentId => parentCommentId!.Value,
                dbParentCommentId => CommentId.Of(dbParentCommentId)
                );
        }
        private void ConfigureCommentCommentReactionTable(EntityTypeBuilder<Comment> builder)
        {
            builder.OwnsMany(p => p.CommentReactions, crs =>
            {
                crs.ToTable("CommentReaction");
                crs.WithOwner().HasForeignKey("CommentId");
                crs.HasKey("Id", "CommentId");

                crs.Property(cr => cr.Id)
                    .HasColumnName("CommentReactionId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        dbId => CommentReactionId.Of(dbId)
                    );

                crs.Property(cr => cr.UserId)
                    .HasConversion(
                        userId => userId.Value,
                        dbUserId => UserId.Of(dbUserId)
                    );

                crs.Property(cr => cr.Emotion)
                    .HasConversion(
                        emotion => emotion.ToString(),
                        dbEmotion => (Emotion)Enum.Parse(typeof(Emotion), dbEmotion)
                    );
            });

            builder.Metadata.FindNavigation(nameof(Comment.CommentReactions))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigurePostRelation(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.PostId)
                .HasConversion(
                id => id.Value,
                dbId => PostId.Of(dbId)
                );
        }
        private void ConfigureCommentCommentReplyTable(EntityTypeBuilder<Comment> builder)
        {
            builder.OwnsMany(c => c.CommentReplyIds, cris =>
            {
                cris.ToTable("CommentReply");
                cris.WithOwner().HasForeignKey("CommentId");
                cris.HasKey("Id");

                cris.Property(cri => cri.Value)
                    .HasColumnName("CommentReplyId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Comment.CommentReplyIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
