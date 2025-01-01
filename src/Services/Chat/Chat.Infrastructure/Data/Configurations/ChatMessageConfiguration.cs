using Chat.Domain.Models;
using Chat.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infrastructure.Data.Configurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            ConfigureChatMessageTable(builder);
            ConfigureChatMessageTableRecipient(builder);
        }
        private void ConfigureChatMessageTable(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(
                messageId => messageId.Value,
                dbId => ChatMessageId.Of(dbId)
                );

            builder.Property(x => x.Message)
                .HasConversion(
                message => message.Value,
                dbMessage => Message.Of(dbMessage)
                );

            builder.Property(x => x.PostedByUser)
                .HasConversion(
                userId => userId.Value,
                dbUserId => UserId.Of(dbUserId)
                );

            builder.Property(x => x.ChatRoomId)
                .HasConversion(
                chatRoomId => chatRoomId.Value,
                dbChatRoomId => ChatRoomId.Of(dbChatRoomId)
                );
        }
        private void ConfigureChatMessageTableRecipient(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.OwnsMany(m => m.ReadByRecipients, rs =>
            {
                rs.ToTable("ReadByRecipient");
                rs.WithOwner().HasForeignKey("ChatMessageId");
                rs.HasKey("Id", "ChatMessageId");

                rs.Property(r => r.Id)
                    .HasColumnName("ReadByRecipientId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        dbId => ReadByRecipientId.Of(dbId)
                    );

                rs.Property(r => r.ReadByUserId)
                    .HasConversion(
                        userId => userId.Value,
                        dbUserId => UserId.Of(dbUserId)
                    );
            });

            builder.Metadata.FindNavigation(nameof(ChatMessage.ReadByRecipients))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
