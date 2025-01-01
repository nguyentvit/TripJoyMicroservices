using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostManagement.Infrastructure.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            ConfigurePostTable(builder);
            ConfigurePostPostReactionTable(builder);
            ConfigureCommentRelation(builder);
            ConfigurePostPostImageTable(builder);
        }
        private void ConfigurePostTable(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                postId => postId.Value,
                dbId => PostId.Of(dbId)
                );

            builder.Property(p => p.UserId)
                .HasConversion(
                userId => userId.Value,
                dbId => UserId.Of(dbId)
                );

            builder.Property(p => p.Content)
                .HasConversion(
                content => content.Value,
                dbContent => Content.Of(dbContent)
                );

            builder.Property(p => p.LikeCount)
                .HasConversion(
                likeCount => likeCount.Value,
                dbLikeCount => LikeCount.Of(dbLikeCount)
                );

            builder.Property(p => p.PostType)
                .HasConversion(
                type => type.ToString(),
                dbType => (PostType)Enum.Parse(typeof(PostType), dbType)
                );
        }
        private void ConfigurePostPostReactionTable(EntityTypeBuilder<Post> builder)
        {
            builder.OwnsMany(p => p.PostReactions, prs =>
            {
                prs.ToTable("PostReaction");
                prs.WithOwner().HasForeignKey("PostId");
                prs.HasKey("Id", "PostId");

                prs.Property(pr => pr.Id)
                    .HasColumnName("PostReactionId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        dbId => PostReactionId.Of(dbId)
                    );

                prs.Property(pr => pr.UserId)
                    .HasConversion(
                    userId => userId.Value,
                    dbUserId => UserId.Of(dbUserId)
                    );

                prs.Property(pr => pr.Emotion)
                    .HasConversion(
                    emotion => emotion.ToString(),
                    dbEmotion => (Emotion)Enum.Parse(typeof(Emotion), dbEmotion)
                    );
            });

            builder.Metadata.FindNavigation(nameof(Post.PostReactions))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureCommentRelation(EntityTypeBuilder<Post> builder)
        {
            builder.OwnsMany(p => p.CommentIds, cis =>
            {
                cis.ToTable("CommentIds");
                cis.WithOwner().HasForeignKey("PostId");

                cis.HasKey("Id");

                cis.Property(ci => ci.Value)
                    .HasColumnName("CommentId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Post.CommentIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigurePostPostImageTable(EntityTypeBuilder<Post> builder)
        {
            builder.OwnsMany(p => p.PostImages, pis =>
            {
                pis.ToTable("PostImage");
                pis.WithOwner().HasForeignKey("PostId");
                pis.HasKey("Id", "PostId");

                pis.Property(pi => pi.Id)
                    .HasColumnName("PostImageId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        dbId => PostImageId.Of(dbId)
                    );

                pis.Property(pi => pi.Image)
                    .HasConversion(
                        image => image.Url,
                        dbImage => Image.Of(dbImage)
                    );
            });

            builder.Metadata.FindNavigation(nameof(Post.PostImages))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
