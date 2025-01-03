﻿// <auto-generated />
using System;
using Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chat.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Chat.Domain.Models.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostedByUser")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("Chat.Domain.Models.ChatRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChatRooms");
                });

            modelBuilder.Entity("Chat.Domain.Models.ChatMessage", b =>
                {
                    b.OwnsMany("Chat.Domain.Entities.ReadByRecipient", "ReadByRecipients", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ReadByRecipientId");

                            b1.Property<Guid>("ChatMessageId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("ReadByUserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id", "ChatMessageId");

                            b1.HasIndex("ChatMessageId");

                            b1.ToTable("ReadByRecipient", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ChatMessageId");
                        });

                    b.Navigation("ReadByRecipients");
                });

            modelBuilder.Entity("Chat.Domain.Models.ChatRoom", b =>
                {
                    b.OwnsMany("Chat.Domain.Entities.ChatRoomMember", "Members", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ChatRoomMemberId");

                            b1.Property<Guid>("ChatRoomId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("MemberId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MemberId");

                            b1.HasKey("Id", "ChatRoomId");

                            b1.HasIndex("ChatRoomId");

                            b1.ToTable("ChatRoomMember", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ChatRoomId");
                        });

                    b.OwnsMany("Chat.Domain.ValueObjects.ChatMessageId", "ChatMessageIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("ChatRoomId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ChatMessageId");

                            b1.HasKey("Id");

                            b1.HasIndex("ChatRoomId");

                            b1.ToTable("ChatMessageIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ChatRoomId");
                        });

                    b.OwnsOne("Chat.Domain.ValueObjects.ChatRoomName", "Name", b1 =>
                        {
                            b1.Property<Guid>("ChatRoomId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("ChatRoomId");

                            b1.ToTable("ChatRooms");

                            b1.WithOwner()
                                .HasForeignKey("ChatRoomId");
                        });

                    b.Navigation("ChatMessageIds");

                    b.Navigation("Members");

                    b.Navigation("Name");
                });
#pragma warning restore 612, 618
        }
    }
}
