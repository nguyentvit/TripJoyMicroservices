using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserAccess.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
            ConfigureUserFriendTable(builder);
            ConfigureUserFriendRequestTable(builder);
            ConfigureUserSentFriendRequestTable(builder);
        }
        private void ConfigureUserFriendTable(EntityTypeBuilder<User> builder)
        {
            builder.OwnsMany(u => u.Friends, uf =>
            {
                uf.ToTable("UserFriends");
                uf.WithOwner().HasForeignKey("UserId");
                uf.HasKey("Id", "UserId");

                uf.Property(f => f.Id)
                    .HasColumnName("UserFriendId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => FriendId.Of(value)
                    );

                uf.Property(f => f.FriendUserId)
                    .HasColumnName("FriendUserId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Of(value)
                    );
            });

            builder.Metadata.FindNavigation(nameof(User.Friends))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureUserFriendRequestTable(EntityTypeBuilder<User> builder)
        {
            builder.OwnsMany(u => u.FriendRequests, ufr =>
            {
                ufr.ToTable("UserFriendRequest");
                ufr.WithOwner().HasForeignKey("UserId");
                ufr.HasKey("Id", "UserId");

                ufr.Property(fr => fr.Id)
                    .HasColumnName("UserFriendRequestId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => FriendRequestId.Of(value)
                    );

                ufr.Property(fr => fr.UserSenderId)
                    .HasColumnName("UserSenderId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Of(value)
                    );
            });

            builder.Metadata.FindNavigation(nameof(User.FriendRequests))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureUserSentFriendRequestTable(EntityTypeBuilder<User> builder)
        {
            builder.OwnsMany(u => u.SentFriendRequests, sfr =>
            {
                sfr.ToTable("UserSentFriendRequest");
                sfr.WithOwner().HasForeignKey("UserId");
                sfr.HasKey("Id", "UserId");

                sfr.Property(sf => sf.Id)
                    .HasColumnName("UserSentFriendRequestId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => SendFriendRequestId.Of(value)
                    );

                sfr.Property(sf => sf.UserReceiverId)
                    .HasColumnName("UserReceiverId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Of(value)
                    );
            });

            builder.Metadata.FindNavigation(nameof(User.SentFriendRequests))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasConversion(
                userId => userId.Value,
                dbId => UserId.Of(dbId)
                );

            builder.Property(u => u.AccountId).HasConversion(
                accountId => accountId.Value,
                dbId => AccountId.Of(dbId)
                );

            builder.ComplexProperty(
                u => u.UserName, nameBuilder =>
                {
                    nameBuilder.Property(n => n.Value)
                        .HasColumnName(nameof(User.UserName))
                        .HasMaxLength(100);
                });

            builder.ComplexProperty(
                u => u.EmailAddress, emailBuilder =>
                {
                    emailBuilder.Property(e => e.Value)
                        .HasColumnName(nameof(User.EmailAddress))
                        .HasMaxLength(50);
                });

            builder.OwnsOne(
                u => u.Phone, phoneBuilder =>
                {
                    phoneBuilder.Property(p => p.Value)
                        .HasColumnName(nameof(User.Phone))
                        .HasMaxLength(20);
                });

            builder.OwnsOne(
                u => u.DateOfBirth, dobBuilder =>
                {
                    dobBuilder.Property(dob => dob.Value)
                        .HasColumnName(nameof(User.DateOfBirth));

                });

            builder.OwnsOne(
                u => u.Avatar, avatarBuilder =>
                {
                    avatarBuilder.Property(a => a.Url)
                        .HasColumnName(nameof(Image.Url));

                    avatarBuilder.Property(a => a.Format)
                        .HasColumnName(nameof(Image.Format))
                        .HasConversion(f => f.ToString(), dbFormat => (ImageFormat)Enum.Parse(typeof(ImageFormat), dbFormat));
                });

            builder.OwnsOne(
                u => u.Address, addressBuilder =>
                {
                    addressBuilder.Property(a => a.Province)
                        .HasColumnName(nameof(Address.Province))
                        .HasMaxLength(50);

                    addressBuilder.Property(a => a.Ward)
                        .HasColumnName(nameof(Address.Ward))
                        .HasMaxLength(50);

                    addressBuilder.Property(a => a.District)
                        .HasColumnName(nameof(Address.District))
                        .HasMaxLength(50);

                    addressBuilder.Property(a => a.Country)
                        .HasColumnName(nameof(Address.Country))
                        .HasDefaultValue("Việt Nam")
                        .HasMaxLength(50);
                });

            builder.Property(u => u.Gender)
                .HasConversion(
                    g => g.ToString(),
                    dbGender => (UserGender)Enum.Parse(typeof(UserGender), dbGender!)
                );

            builder.Property(u => u.Status)
                .HasConversion(
                    s => s.ToString(),
                    dbStatus => (AccountStatus)Enum.Parse(typeof(AccountStatus), dbStatus)
                );
        }
    }
}
