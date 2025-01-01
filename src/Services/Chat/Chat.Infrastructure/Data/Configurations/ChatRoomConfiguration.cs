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
            builder.OwnsMany(r => r.ChatMessageIds, mis =>
            {
                mis.ToTable("ChatMessageIds");

                mis.WithOwner().HasForeignKey("ChatRoomId");

                mis.HasKey("Id");

                mis.Property(mi => mi.Value)
                    .HasColumnName("ChatMessageId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(ChatRoom.ChatMessageIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
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

            builder.Metadata.FindNavigation(nameof(ChatRoom.Members))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
