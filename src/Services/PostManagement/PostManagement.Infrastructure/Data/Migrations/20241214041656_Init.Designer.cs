﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PostManagement.Infrastructure.Data;

#nullable disable

namespace PostManagement.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241214041656_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PostManagement.Domain.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentCommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PostManagement.Domain.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<string>("PostType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShareStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasDiscriminator().HasValue("Post");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PostManagement.Domain.Models.PlanPost", b =>
                {
                    b.HasBaseType("PostManagement.Domain.Models.Post");

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PlanEndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PlanStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vehicle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ComplexProperty<Dictionary<string, object>>("ProvinceEnd", "PostManagement.Domain.Models.PlanPost.ProvinceEnd#Province", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("ProvinceId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ProvinceIdEnd");

                            b1.Property<string>("ProvinceName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ProvinceNameEnd");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("ProvinceStart", "PostManagement.Domain.Models.PlanPost.ProvinceStart#Province", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("ProvinceId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ProvinceIdStart");

                            b1.Property<string>("ProvinceName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ProvinceNameStart");
                        });

                    b.HasDiscriminator().HasValue("PlanPost");
                });

            modelBuilder.Entity("PostManagement.Domain.Models.Comment", b =>
                {
                    b.OwnsMany("PostManagement.Domain.Entities.CommentReaction", "CommentReactions", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("CommentReactionId");

                            b1.Property<Guid>("CommentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Emotion")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id", "CommentId");

                            b1.HasIndex("CommentId");

                            b1.ToTable("CommentReaction", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CommentId");
                        });

                    b.Navigation("CommentReactions");
                });

            modelBuilder.Entity("PostManagement.Domain.Models.Post", b =>
                {
                    b.OwnsMany("PostManagement.Domain.Entities.PostImage", "PostImages", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PostImageId");

                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Image")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id", "PostId");

                            b1.HasIndex("PostId");

                            b1.ToTable("PostImage", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsMany("PostManagement.Domain.Entities.PostReaction", "PostReactions", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PostReactionId");

                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Emotion")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id", "PostId");

                            b1.HasIndex("PostId");

                            b1.ToTable("PostReaction", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsMany("PostManagement.Domain.Entities.TagUser", "TagUsers", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("TagUserId");

                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id", "PostId");

                            b1.HasIndex("PostId");

                            b1.ToTable("TagUser", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsMany("PostManagement.Domain.ValueObjects.CommentId", "CommentIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("CommentId");

                            b1.HasKey("Id");

                            b1.HasIndex("PostId");

                            b1.ToTable("CommentIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.Navigation("CommentIds");

                    b.Navigation("PostImages");

                    b.Navigation("PostReactions");

                    b.Navigation("TagUsers");
                });

            modelBuilder.Entity("PostManagement.Domain.Models.PlanPost", b =>
                {
                    b.OwnsMany("PostManagement.Domain.Entities.PostPlanLocation", "PostPlanLocations", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PostPlanLocationId");

                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("EstimatedStartDate")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("LocationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Order")
                                .HasColumnType("int");

                            b1.HasKey("Id", "PostId");

                            b1.HasIndex("PostId");

                            b1.ToTable("PostPlanLocation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PostId");

                            b1.OwnsOne("PostManagement.Domain.ValueObjects.Coordinates", "Coordinates", b2 =>
                                {
                                    b2.Property<Guid>("PostPlanLocationId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("PostPlanLocationPostId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<double>("Latitude")
                                        .HasColumnType("float")
                                        .HasColumnName("Latitude");

                                    b2.Property<double>("Longitude")
                                        .HasColumnType("float")
                                        .HasColumnName("Longitude");

                                    b2.HasKey("PostPlanLocationId", "PostPlanLocationPostId");

                                    b2.ToTable("PostPlanLocation");

                                    b2.WithOwner()
                                        .HasForeignKey("PostPlanLocationId", "PostPlanLocationPostId");
                                });

                            b1.Navigation("Coordinates")
                                .IsRequired();
                        });

                    b.Navigation("PostPlanLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
