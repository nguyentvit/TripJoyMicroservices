﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserAccess.Infrastructure.Data;

#nullable disable

namespace UserAccess.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241108083826_remove-phonenumber")]
    partial class removephonenumber
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserAccess.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ComplexProperty<Dictionary<string, object>>("EmailAddress", "UserAccess.Domain.Models.User.EmailAddress#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("EmailAddress");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("UserName", "UserAccess.Domain.Models.User.UserName#UserName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("UserName");
                        });

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserAccess.Domain.Models.User", b =>
                {
                    b.OwnsMany("UserAccess.Domain.Entities.Friend", "Friends", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserFriendId");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("FriendUserId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("FriendUserId");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id", "UserId");

                            b1.HasIndex("UserId");

                            b1.ToTable("UserFriends", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("UserAccess.Domain.Entities.FriendRequest", "FriendRequests", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserFriendRequestId");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("UserSenderId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserSenderId");

                            b1.HasKey("Id", "UserId");

                            b1.HasIndex("UserId");

                            b1.ToTable("UserFriendRequest", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("UserAccess.Domain.Entities.SentFriendRequest", "SentFriendRequests", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserSentFriendRequestId");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("UserReceiverId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserReceiverId");

                            b1.HasKey("Id", "UserId");

                            b1.HasIndex("UserId");

                            b1.ToTable("UserSentFriendRequest", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("UserAccess.Domain.ValueObject.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasDefaultValue("Việt Nam")
                                .HasColumnName("Country");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("District");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Province");

                            b1.Property<string>("Ward")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Ward");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("UserAccess.Domain.ValueObject.Date", "DateOfBirth", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2")
                                .HasColumnName("DateOfBirth");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("UserAccess.Domain.ValueObject.Image", "Avatar", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Format")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Format");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Url");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("UserAccess.Domain.ValueObject.PhoneNumber", "Phone", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)")
                                .HasColumnName("Phone");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Avatar");

                    b.Navigation("DateOfBirth");

                    b.Navigation("FriendRequests");

                    b.Navigation("Friends");

                    b.Navigation("Phone");

                    b.Navigation("SentFriendRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
