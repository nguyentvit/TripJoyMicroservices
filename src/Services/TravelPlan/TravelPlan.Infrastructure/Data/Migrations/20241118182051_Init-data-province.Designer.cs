﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelPlan.Infrastructure.Data;

#nullable disable

namespace TravelPlan.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241118182051_Init-data-province")]
    partial class Initdataprovince
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TravelPlan.Domain.Models.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EndDate");

                    b.Property<decimal>("EstimatedBudget")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("EstimatedBudget");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Method");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Note");

                    b.Property<Guid>("ProvinceEndId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProvinceStartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartDate");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("TravelPlan.Domain.Models.PlanLocation", b =>
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

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LocationId");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Note");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasColumnName("Order");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("PlanLocations");
                });

            modelBuilder.Entity("TravelPlan.Domain.Models.Province", b =>
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = new Guid("469d51e8-8962-4684-9aa4-1155b03a0f00"),
                            Name = "An Giang"
                        },
                        new
                        {
                            Id = new Guid("d59edfa2-268c-44b8-a060-967f94873bb1"),
                            Name = "Bà Rịa-Vũng Tàu"
                        },
                        new
                        {
                            Id = new Guid("a5f509f4-52ee-487f-a647-facd36b7b155"),
                            Name = "Bắc Giang"
                        },
                        new
                        {
                            Id = new Guid("faf91b46-ae81-4270-98f7-e4b2662773df"),
                            Name = "Bắc Kạn"
                        },
                        new
                        {
                            Id = new Guid("585928da-e3d3-4f3a-ae84-07dc9c5c8ee3"),
                            Name = "Bạc Liêu"
                        },
                        new
                        {
                            Id = new Guid("57a47d44-9eb2-4d0e-978e-00233b3b6bc6"),
                            Name = "Bắc Ninh"
                        },
                        new
                        {
                            Id = new Guid("255f6085-ff1f-4cd8-b074-8066a440c28b"),
                            Name = "Bến Tre"
                        },
                        new
                        {
                            Id = new Guid("b4e1537f-a0eb-4df0-9642-9c1456d7c2e9"),
                            Name = "Bình Định"
                        },
                        new
                        {
                            Id = new Guid("38a1f7e8-0c1a-4f26-afba-492a2543c5b8"),
                            Name = "Bình Dương"
                        },
                        new
                        {
                            Id = new Guid("7b41d512-dad4-46ef-989e-8f43445a73e6"),
                            Name = "Bình Phước"
                        },
                        new
                        {
                            Id = new Guid("e9a7dc99-b998-4e6d-a573-5a6faf65f952"),
                            Name = "Bình Thuận"
                        },
                        new
                        {
                            Id = new Guid("840db29d-c732-4b82-a6ec-72ab13aeb103"),
                            Name = "Cà Mau"
                        },
                        new
                        {
                            Id = new Guid("a6e5d286-e7bb-4cc8-9942-683499a69389"),
                            Name = "Cần Thơ"
                        },
                        new
                        {
                            Id = new Guid("d6760ae7-be27-4f3b-a609-d4b55cfbeede"),
                            Name = "Cao Bằng"
                        },
                        new
                        {
                            Id = new Guid("4fee88a7-ba05-47a4-81d3-0da99e92b04a"),
                            Name = "Đà Nẵng"
                        },
                        new
                        {
                            Id = new Guid("75fc3afa-fcd1-4d5a-af72-6a0f18cb9356"),
                            Name = "Đắk Lắk"
                        },
                        new
                        {
                            Id = new Guid("0a4985fa-f4dc-4e3a-9a36-8bd7bec7036c"),
                            Name = "Đắk Nông"
                        },
                        new
                        {
                            Id = new Guid("0bb13b94-9b70-4f78-bc7b-70d5a7c37dcf"),
                            Name = "Điện Biên"
                        },
                        new
                        {
                            Id = new Guid("d0d4f625-4371-4689-b35e-4edd81433df7"),
                            Name = "Đồng Nai"
                        },
                        new
                        {
                            Id = new Guid("4b531bf0-efe5-4f70-8f13-0b136a01b750"),
                            Name = "Đồng Tháp"
                        },
                        new
                        {
                            Id = new Guid("c054cd3b-cc8b-4de9-82a5-945f6189d00d"),
                            Name = "Gia Lai"
                        },
                        new
                        {
                            Id = new Guid("1868703f-7c20-42b6-93ce-67b59ab95afd"),
                            Name = "Hà Giang"
                        },
                        new
                        {
                            Id = new Guid("2534c856-0afa-4c15-8e28-951418b77509"),
                            Name = "Hà Nam"
                        },
                        new
                        {
                            Id = new Guid("ea25cccf-c07e-4534-8708-893aa2ab8067"),
                            Name = "Hà Nội"
                        },
                        new
                        {
                            Id = new Guid("41ee2ee8-1819-4876-a9b6-5d24ab401870"),
                            Name = "Hà Tĩnh"
                        },
                        new
                        {
                            Id = new Guid("f9dd5bf5-f8c6-48a7-ac2d-6463107f5300"),
                            Name = "Hải Dương"
                        },
                        new
                        {
                            Id = new Guid("9e335a54-3f37-41e0-b698-503337f1825b"),
                            Name = "Hải Phòng"
                        },
                        new
                        {
                            Id = new Guid("b0cc04c8-00a4-4356-a075-a955a76efa83"),
                            Name = "Hậu Giang"
                        },
                        new
                        {
                            Id = new Guid("f2ec6566-a290-4f4e-bc5f-5556e2833b9f"),
                            Name = "TP. Hồ Chí Minh"
                        },
                        new
                        {
                            Id = new Guid("9a6c53e9-ba9f-45b6-b6a1-a2eb863ba89d"),
                            Name = "Hòa Bình"
                        },
                        new
                        {
                            Id = new Guid("dcacf024-0d9c-42ff-ac92-499c77cae93b"),
                            Name = "Hưng Yên"
                        },
                        new
                        {
                            Id = new Guid("771774f3-de20-4849-b905-80a3482628ca"),
                            Name = "Khánh Hòa"
                        },
                        new
                        {
                            Id = new Guid("0240a6f0-41b3-48e6-8329-330b0da8ec5d"),
                            Name = "Kiên Giang"
                        },
                        new
                        {
                            Id = new Guid("d2f4b2ed-d339-4595-8215-17be04839a14"),
                            Name = "Kon Tum"
                        },
                        new
                        {
                            Id = new Guid("c95036a6-cb05-40dd-b795-f2848beba466"),
                            Name = "Lai Châu"
                        },
                        new
                        {
                            Id = new Guid("55080d85-c728-4053-b6ec-ba6eff901417"),
                            Name = "Lâm Đồng"
                        },
                        new
                        {
                            Id = new Guid("53e495ab-4a60-497a-a93f-88fc755ec7c5"),
                            Name = "Lạng Sơn"
                        },
                        new
                        {
                            Id = new Guid("f88bae71-0f08-4cd7-8400-1660c2291e4d"),
                            Name = "Lào Cai"
                        },
                        new
                        {
                            Id = new Guid("13cee0ac-aec3-4449-afef-eb9881743d15"),
                            Name = "Long An"
                        },
                        new
                        {
                            Id = new Guid("674e216b-462f-4faa-babd-d2a7a7898cae"),
                            Name = "Nam Định"
                        },
                        new
                        {
                            Id = new Guid("0be9dfa7-e19c-4dd3-8ae2-d134d8800ec9"),
                            Name = "Nghệ An"
                        },
                        new
                        {
                            Id = new Guid("106e29fe-6f1e-4357-b6b7-fae7a07b0cc7"),
                            Name = "Ninh Bình"
                        },
                        new
                        {
                            Id = new Guid("a742b818-97b3-4eac-b0bd-5a5f6fae29eb"),
                            Name = "Ninh Thuận"
                        },
                        new
                        {
                            Id = new Guid("41019a0f-8109-4340-8117-1046a61e8968"),
                            Name = "Phú Thọ"
                        },
                        new
                        {
                            Id = new Guid("1fd35b1d-719b-45e8-868d-cfd50db49554"),
                            Name = "Phú Yên"
                        },
                        new
                        {
                            Id = new Guid("bc2d77bd-222f-4c47-b63f-a5c9c8e5eca3"),
                            Name = "Quảng Bình"
                        },
                        new
                        {
                            Id = new Guid("f42dce30-f80c-40fd-89d3-242d6ab413f9"),
                            Name = "Quảng Nam"
                        },
                        new
                        {
                            Id = new Guid("33977811-8d62-4c1a-ae48-cca61fc8b8e6"),
                            Name = "Quảng Ngãi"
                        },
                        new
                        {
                            Id = new Guid("d9da5b2c-14a2-4e2c-ac2e-ccab8c5a2c2e"),
                            Name = "Quảng Ninh"
                        },
                        new
                        {
                            Id = new Guid("705493ad-2f3f-4e1f-a7f4-b6edf1bc45db"),
                            Name = "Quảng Trị"
                        },
                        new
                        {
                            Id = new Guid("b6994a44-4ceb-4235-9072-f3cef8e6ff1d"),
                            Name = "Sóc Trăng"
                        },
                        new
                        {
                            Id = new Guid("fc467819-7139-4bc4-854f-222395bd3805"),
                            Name = "Sơn La"
                        },
                        new
                        {
                            Id = new Guid("a651949b-ecbd-4984-9959-bbaa590a29d2"),
                            Name = "Tây Ninh"
                        },
                        new
                        {
                            Id = new Guid("8b365a56-c2e4-4061-98be-0521d3ea918d"),
                            Name = "Thái Bình"
                        },
                        new
                        {
                            Id = new Guid("0f6c60e0-6ee6-4982-97d3-b65f7a9429b9"),
                            Name = "Thái Nguyên"
                        },
                        new
                        {
                            Id = new Guid("7e3a4c8c-0382-42eb-b158-dd4c2a7efd04"),
                            Name = "Thanh Hóa"
                        },
                        new
                        {
                            Id = new Guid("3305760c-f72d-4926-83e5-5ee0d04bf8c6"),
                            Name = "Thừa Thiên - Huế"
                        },
                        new
                        {
                            Id = new Guid("0f9c56d5-4778-475f-bc98-90c5f614a941"),
                            Name = "Tiền Giang"
                        },
                        new
                        {
                            Id = new Guid("931661ce-783e-41be-9b8e-685c57861216"),
                            Name = "Trà Vinh"
                        },
                        new
                        {
                            Id = new Guid("69dadd78-83e8-4db9-be97-7abed515bb7a"),
                            Name = "Tuyên Quang"
                        },
                        new
                        {
                            Id = new Guid("cb2dfde5-67bd-46b9-87fc-aeb667c0b989"),
                            Name = "Vĩnh Long"
                        },
                        new
                        {
                            Id = new Guid("2f79089c-bb98-4ba0-80df-e73e56595507"),
                            Name = "Vĩnh Phúc"
                        },
                        new
                        {
                            Id = new Guid("1bd0e869-2569-4e01-b81e-1808236ff92c"),
                            Name = "Yên Bái"
                        });
                });

            modelBuilder.Entity("TravelPlan.Domain.Models.Plan", b =>
                {
                    b.OwnsMany("TravelPlan.Domain.Entities.PlanInvitation", "Invitations", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PlanInvitationId");

                            b1.Property<Guid>("PlanId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("InviteeId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("InviteeId");

                            b1.Property<Guid>("InviterId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("InviterId");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id", "PlanId");

                            b1.HasIndex("PlanId");

                            b1.ToTable("PlanInvitation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PlanId");
                        });

                    b.OwnsMany("TravelPlan.Domain.Entities.PlanMember", "Members", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PlanMemberId");

                            b1.Property<Guid>("PlanId")
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

                            b1.Property<string>("Role")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Role");

                            b1.HasKey("Id", "PlanId");

                            b1.HasIndex("PlanId");

                            b1.ToTable("PlanMember", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PlanId");
                        });

                    b.OwnsMany("TravelPlan.Domain.Entities.PlanVehicle", "Vehicles", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PlanVehicleId");

                            b1.Property<Guid>("PlanId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Vehicle")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Vehicle");

                            b1.HasKey("Id", "PlanId");

                            b1.HasIndex("PlanId");

                            b1.ToTable("PlanVehicle", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PlanId");
                        });

                    b.OwnsOne("TravelPlan.Domain.ValueObjects.Image", "Avatar", b1 =>
                        {
                            b1.Property<Guid>("PlanId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Avatar");

                            b1.HasKey("PlanId");

                            b1.ToTable("Plans");

                            b1.WithOwner()
                                .HasForeignKey("PlanId");
                        });

                    b.OwnsMany("TravelPlan.Domain.ValueObjects.PlanLocationId", "PlanLocationIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("PlanId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PlanLocationId");

                            b1.HasKey("Id");

                            b1.HasIndex("PlanId");

                            b1.ToTable("PlanLocationIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PlanId");
                        });

                    b.Navigation("Avatar");

                    b.Navigation("Invitations");

                    b.Navigation("Members");

                    b.Navigation("PlanLocationIds");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("TravelPlan.Domain.Models.PlanLocation", b =>
                {
                    b.OwnsMany("TravelPlan.Domain.Entities.PlanLocationExpense", "Expenses", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PlanLocationExpenseId");

                            b1.Property<Guid>("PlanLocationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Amount");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Note")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Note");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Title");

                            b1.HasKey("Id", "PlanLocationId");

                            b1.HasIndex("PlanLocationId");

                            b1.ToTable("PlanLocationExpense", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PlanLocationId");
                        });

                    b.OwnsMany("TravelPlan.Domain.Entities.PlanLocationImage", "Images", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PlanLocationImageId");

                            b1.Property<Guid>("PlanLocationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Image")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Image");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Title");

                            b1.Property<Guid>("UserIdUploaded")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserIdUploaded");

                            b1.HasKey("Id", "PlanLocationId");

                            b1.HasIndex("PlanLocationId");

                            b1.ToTable("PlanLocationImage", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PlanLocationId");
                        });

                    b.Navigation("Expenses");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("TravelPlan.Domain.Models.Province", b =>
                {
                    b.OwnsMany("TravelPlan.Domain.ValueObjects.PlanId", "PlanIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("ProvinceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PlanId");

                            b1.HasKey("Id");

                            b1.HasIndex("ProvinceId");

                            b1.ToTable("PlanIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProvinceId");
                        });

                    b.Navigation("PlanIds");
                });
#pragma warning restore 612, 618
        }
    }
}
