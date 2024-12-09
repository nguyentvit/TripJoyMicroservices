using Chat.Domain.Enums;
using Chat.Domain.Models;
using Chat.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infrastructure.Data.Configurations
{
    public class ChatRoomConfiguration : IEntityTypeConfiguration<ChatRoom>
    {
        public void Configure(EntityTypeBuilder<ChatRoom> builder)
        {
            ConfigureChatRoomTable(builder);
            ConfigureChatRoomChatMessageTable(builder);
            ConfigureChatRoomChatRoomMemberTable(builder);
        }
        private void ConfigureChatRoomTable(EntityTypeBuilder<ChatRoom> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(
                roomId => roomId.Value,
                dbId => ChatRoomId.Of(dbId)
                );

            builder.Property(x => x.Type)
                .HasConversion(
                type => type.ToString(),
                dbType => (ChatRoomType)Enum.Parse(typeof(ChatRoomType), dbType)
                );

            //builder.OwnsOne(x => x.PlanId, planIdBuilder =>
            //{
            //    planIdBuilder.Property(x => x.Value)
            //        .HasColumnName(nameof(ChatRoom.PlanId));
            //});

            builder.Property(x => x.PlanId)
                .HasConversion(
                    planId => planId == null ? (Guid?)null : planId.Value,
                    value => value == null ? null : PlanId.Of(value.Value)
                ); ;

            builder.OwnsOne(x => x.Name, nameBuilder =>
            {
                nameBuilder.Property(x => x.Value)
                    .HasColumnName(nameof(ChatRoom.Name));
            });
        }
        private void ConfigureChatRoomChatMessageTable(EntityTypeBuilder<ChatRoom> builder)
        {
            builder.OwnsMany(r => r.Messages, ms =>
            {
                ms.ToTable("ChatMessage");
                ms.WithOwner().HasForeignKey("ChatRoomId");
                ms.HasKey("Id", "ChatRoomId");

                ms.Property(m => m.Id)
                    .HasColumnName("ChatMessageId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        dbId => ChatMessageId.Of(dbId)
                    );

                ms.Property(m => m.PostedByUser)
                    .HasColumnName("PostedByUser")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Of(value)
                    );

                ms.Property(m => m.Message)
                    .HasColumnName("Message")
                    .HasConversion(
                        message => message.Value,
                        dbMessage => Message.Of(dbMessage)
                    );
            });
        }
        private void ConfigureChatRoomChatRoomMemberTable(EntityTypeBuilder<ChatRoom> builder)
        {
            builder.OwnsMany(r => r.Members, rms =>
            {
                rms.ToTable("ChatRoomMember");
                rms.WithOwner().HasForeignKey("ChatRoomId");
                rms.HasKey("Id", "ChatRoomId");

                rms.Property(rm => rm.Id)
                    .HasColumnName("ChatRoomMemberId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => ChatRoomMemberId.Of(value)
                    );

                rms.Property(rm => rm.MemberId)
                    .HasColumnName("MemberId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Of(value)
                    );
            });
        }
    }
}
