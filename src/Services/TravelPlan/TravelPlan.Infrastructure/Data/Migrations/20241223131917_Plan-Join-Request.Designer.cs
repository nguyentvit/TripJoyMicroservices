﻿// <auto-generated />
using System;
using System.Collections.Generic;
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
    [Migration("20241223131917_Plan-Join-Request")]
    partial class PlanJoinRequest
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

                    b.Property<string>("JoinStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("JoinStatus");

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

                    b.Property<string>("Vehicle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vehicle");

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

                    b.Property<DateTime>("EstimatedStartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EstimatedStartDate");

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

                    b.ComplexProperty<Dictionary<string, object>>("Coordinates", "TravelPlan.Domain.Models.PlanLocation.Coordinates#Coordinates", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");
                        });

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
                            Id = new Guid("66b66c13-269f-4f6e-a673-2e085e9c8109"),
                            Name = "Vĩnh Long"
                        },
                        new
                        {
                            Id = new Guid("d2cfa81a-87fd-4fc2-bfd4-05eb5939110d"),
                            Name = "Bắc Ninh"
                        },
                        new
                        {
                            Id = new Guid("af7f2569-0efe-47ad-871b-471f53aa5388"),
                            Name = "Bình Định"
                        },
                        new
                        {
                            Id = new Guid("c869d581-d3bc-4fc7-9c65-6f9bc6776324"),
                            Name = "Hà Nam"
                        },
                        new
                        {
                            Id = new Guid("a995c907-1b5b-4fbb-bfd7-781b1ef3ce87"),
                            Name = "Sóc Trăng"
                        },
                        new
                        {
                            Id = new Guid("0a56c5b7-8283-4c22-a555-81c8c77efb9f"),
                            Name = "Hà Nội"
                        },
                        new
                        {
                            Id = new Guid("43f04efd-9498-416e-bdf8-e474eb98c48e"),
                            Name = "Bình Dương"
                        },
                        new
                        {
                            Id = new Guid("f520027b-7e86-47b3-8fe3-676498c6929d"),
                            Name = "Điện Biên"
                        },
                        new
                        {
                            Id = new Guid("2fc5e4cd-eddb-44a2-a792-56292abea2db"),
                            Name = "Đà Nẵng"
                        },
                        new
                        {
                            Id = new Guid("b9dfdaca-bb4f-4921-adfe-0f5173ad456e"),
                            Name = "Hải Phòng"
                        },
                        new
                        {
                            Id = new Guid("8e4e0f95-55ab-48dd-9aa7-70b6d63b435c"),
                            Name = "Cần Thơ"
                        },
                        new
                        {
                            Id = new Guid("1eadd14f-31ae-4046-abca-3cfdd5bf43e3"),
                            Name = "Thành phố Hồ Chí Minh"
                        },
                        new
                        {
                            Id = new Guid("89d35cc2-8cdf-41b4-97d0-4dd8b5199ae3"),
                            Name = "An Giang"
                        },
                        new
                        {
                            Id = new Guid("8cc96e0f-07be-4874-ac23-e6297fcacc9b"),
                            Name = "Bà Rịa - Vũng Tàu"
                        },
                        new
                        {
                            Id = new Guid("bf64f2ac-a7fc-40a8-b4ee-317cf80a0e5e"),
                            Name = "Bắc Giang"
                        },
                        new
                        {
                            Id = new Guid("35555d6d-2292-4c5e-aa64-79c00560d358"),
                            Name = "Bắc Kạn"
                        },
                        new
                        {
                            Id = new Guid("d05bbf91-5e47-4155-bb29-e3ebc56e18ca"),
                            Name = "Bạc Liêu"
                        },
                        new
                        {
                            Id = new Guid("8e1c7a51-6505-45b7-b9c5-291aadbfba45"),
                            Name = "Bến Tre"
                        },
                        new
                        {
                            Id = new Guid("94983e70-6088-43bf-a69f-5e3afde1dc0a"),
                            Name = "Bình Phước"
                        },
                        new
                        {
                            Id = new Guid("0a97deff-644d-49f2-a710-70e1c54dc4ce"),
                            Name = "Bình Thuận"
                        },
                        new
                        {
                            Id = new Guid("7c12d94c-83bc-40aa-8912-83c9e6ca25c7"),
                            Name = "Cà Mau"
                        },
                        new
                        {
                            Id = new Guid("41fda8a9-66a2-4749-8f6f-5772edf88d5b"),
                            Name = "Cao Bằng"
                        },
                        new
                        {
                            Id = new Guid("1685de7f-9f41-4620-9ee0-a133a802d3fc"),
                            Name = "Đắk Lắk"
                        },
                        new
                        {
                            Id = new Guid("84661e95-3027-42b6-977b-bd204eaa8564"),
                            Name = "Đắk Nông"
                        },
                        new
                        {
                            Id = new Guid("6b08f721-a3cf-412f-9bb0-1ee200e1b3d2"),
                            Name = "Đồng Nai"
                        },
                        new
                        {
                            Id = new Guid("b4dc9369-10e3-4a37-9d7e-e6cfb609e40d"),
                            Name = "Đồng Tháp"
                        },
                        new
                        {
                            Id = new Guid("c5556c9e-d51f-4bbf-a190-40ebf3ffc8b7"),
                            Name = "Gia Lai"
                        },
                        new
                        {
                            Id = new Guid("6980124c-aaa3-4807-a188-846ef6b7f090"),
                            Name = "Hà Giang"
                        },
                        new
                        {
                            Id = new Guid("5ecd8fa9-468b-418c-afe5-5e9098ab0659"),
                            Name = "Hà Tĩnh"
                        },
                        new
                        {
                            Id = new Guid("64930e47-3e18-4878-9830-a86ca00e51df"),
                            Name = "Hải Dương"
                        },
                        new
                        {
                            Id = new Guid("35370d91-daba-4423-aa4f-7f555eb5427f"),
                            Name = "Hòa Bình"
                        },
                        new
                        {
                            Id = new Guid("ad09d53a-fe5b-45aa-a1d6-4afbcd673bfc"),
                            Name = "Hậu Giang"
                        },
                        new
                        {
                            Id = new Guid("e874352a-3a44-4398-ba8a-a3fb2b69adf7"),
                            Name = "Hưng Yên"
                        },
                        new
                        {
                            Id = new Guid("a9891668-008e-4f51-98c3-60c4ade39847"),
                            Name = "Khánh Hòa"
                        },
                        new
                        {
                            Id = new Guid("3380b8f5-e854-4e72-8021-c6f2146655f0"),
                            Name = "Kiên Giang"
                        },
                        new
                        {
                            Id = new Guid("e21ab1b1-d75d-4d7f-af0a-109e015e6b10"),
                            Name = "Kon Tum"
                        },
                        new
                        {
                            Id = new Guid("0b97fdd6-4fce-4339-86db-19ada04ddabe"),
                            Name = "Lai Châu"
                        },
                        new
                        {
                            Id = new Guid("3ddceedf-a16b-4fac-b92f-f2e7211f878a"),
                            Name = "Lâm Đồng"
                        },
                        new
                        {
                            Id = new Guid("fab88a89-58a2-4813-b24c-99d15978622a"),
                            Name = "Lạng Sơn"
                        },
                        new
                        {
                            Id = new Guid("2488ec0f-0086-428d-88c2-8b4551636b31"),
                            Name = "Lào Cai"
                        },
                        new
                        {
                            Id = new Guid("db62b353-8aa3-414b-8b0f-d9a6f1ca1ae3"),
                            Name = "Long An"
                        },
                        new
                        {
                            Id = new Guid("39daa34e-b0b1-44ed-b54e-84123563bd9d"),
                            Name = "Nam Định"
                        },
                        new
                        {
                            Id = new Guid("4d065da1-a78b-4f0e-97c6-0bb5d3f55ffb"),
                            Name = "Nghệ An"
                        },
                        new
                        {
                            Id = new Guid("e79a15f0-2a14-4fb8-8299-f2f866beedc9"),
                            Name = "Ninh Bình"
                        },
                        new
                        {
                            Id = new Guid("2c3f37aa-57af-4d55-85a5-3074d13bd40c"),
                            Name = "Ninh Thuận"
                        },
                        new
                        {
                            Id = new Guid("5dc9d3aa-7c7a-4d71-b481-746ab155e1e8"),
                            Name = "Phú Thọ"
                        },
                        new
                        {
                            Id = new Guid("0f44eeb8-2eb6-4d9c-b2f9-e17fa0645307"),
                            Name = "Phú Yên"
                        },
                        new
                        {
                            Id = new Guid("ef6b32ff-ffbe-43ea-9f16-9c379e029f90"),
                            Name = "Quảng Bình"
                        },
                        new
                        {
                            Id = new Guid("db5a59f0-5d3a-4307-a5ee-9898f9f781c9"),
                            Name = "Quảng Nam"
                        },
                        new
                        {
                            Id = new Guid("a690946d-3046-494b-9641-b2ac361b51e0"),
                            Name = "Quảng Ngãi"
                        },
                        new
                        {
                            Id = new Guid("823d7032-ac29-4904-81a3-37e2612c1db2"),
                            Name = "Quảng Ninh"
                        },
                        new
                        {
                            Id = new Guid("b2346372-4d2e-4597-a96f-b12d2f6c66fb"),
                            Name = "Quảng Trị"
                        },
                        new
                        {
                            Id = new Guid("d1e3c73a-02ab-463c-965d-5ba1cf74857f"),
                            Name = "Sóc Trăng"
                        },
                        new
                        {
                            Id = new Guid("7b916c3f-04a4-43af-a7bd-d128a3a36293"),
                            Name = "Sơn La"
                        },
                        new
                        {
                            Id = new Guid("a7e2cc11-2ffa-40b4-be70-f2f253f33886"),
                            Name = "Tây Ninh"
                        },
                        new
                        {
                            Id = new Guid("526fa4ef-e9d8-4575-84fd-c0f2ef9d96ea"),
                            Name = "Thái Bình"
                        },
                        new
                        {
                            Id = new Guid("0d57d40b-90dd-43a1-be67-c3d01a33a90d"),
                            Name = "Thái Nguyên"
                        },
                        new
                        {
                            Id = new Guid("7ce6ebe3-f3c8-40da-8dbe-cf533aed0077"),
                            Name = "Thanh Hóa"
                        },
                        new
                        {
                            Id = new Guid("ba149ec2-c97c-46d2-86d1-be3af2ab008e"),
                            Name = "Thừa Thiên Huế"
                        },
                        new
                        {
                            Id = new Guid("0815b31e-4329-4ca5-88b4-2a137c09bdf1"),
                            Name = "Tiền Giang"
                        },
                        new
                        {
                            Id = new Guid("4942b167-0eaa-4776-bfb3-43ad85e190b5"),
                            Name = "Trà Vinh"
                        },
                        new
                        {
                            Id = new Guid("4938e4e5-f624-41bf-b3f6-6b4dbc50b246"),
                            Name = "Tuyên Quang"
                        },
                        new
                        {
                            Id = new Guid("e4775923-9725-497d-ad4e-225772eb7e68"),
                            Name = "Vĩnh Phúc"
                        },
                        new
                        {
                            Id = new Guid("5dffc807-aadd-4f33-98ba-35209158f41f"),
                            Name = "Yên Bái"
                        },
                        new
                        {
                            Id = new Guid("2fc19558-5ff8-4b39-be3d-950de1928b93"),
                            Name = "Thái Bình"
                        });
                });

            modelBuilder.Entity("TravelPlan.Domain.Models.Plan", b =>
                {
                    b.OwnsMany("TravelPlan.Domain.Entities.PlanInvitation", "PlanInvitations", b1 =>
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

                    b.OwnsMany("TravelPlan.Domain.Entities.PlanJoinRequest", "PlanJoinRequests", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PlanJoinRequestId");

                            b1.Property<Guid>("PlanId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Introduction")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserId");

                            b1.HasKey("Id", "PlanId");

                            b1.HasIndex("PlanId");

                            b1.ToTable("PlanJoinRequest", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PlanId");
                        });

                    b.OwnsMany("TravelPlan.Domain.Entities.PlanMember", "PlanMembers", b1 =>
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

                    b.Navigation("PlanInvitations");

                    b.Navigation("PlanJoinRequests");

                    b.Navigation("PlanLocationIds");

                    b.Navigation("PlanMembers");
                });

            modelBuilder.Entity("TravelPlan.Domain.Models.PlanLocation", b =>
                {
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

                    b.OwnsMany("TravelPlan.Domain.Entities.PlanLocationUserSpender", "PlanLocationUserSpenders", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PlanLocationUserSpenderId");

                            b1.Property<Guid>("PlanLocationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("CreatedAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("datetime2");

                            b1.Property<string>("LastModifiedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("UserSpenderId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserSpenderId");

                            b1.HasKey("Id", "PlanLocationId");

                            b1.HasIndex("PlanLocationId");

                            b1.ToTable("PlanLocationUserSpender", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PlanLocationId");
                        });

                    b.OwnsOne("TravelPlan.Domain.ValueObjects.Date", "CompletionDate", b1 =>
                        {
                            b1.Property<Guid>("PlanLocationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2")
                                .HasColumnName("CompletionDate");

                            b1.HasKey("PlanLocationId");

                            b1.ToTable("PlanLocations");

                            b1.WithOwner()
                                .HasForeignKey("PlanLocationId");
                        });

                    b.OwnsOne("TravelPlan.Domain.ValueObjects.Money", "Amount", b1 =>
                        {
                            b1.Property<Guid>("PlanLocationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Amount");

                            b1.HasKey("PlanLocationId");

                            b1.ToTable("PlanLocations");

                            b1.WithOwner()
                                .HasForeignKey("PlanLocationId");
                        });

                    b.OwnsOne("TravelPlan.Domain.ValueObjects.UserId", "PayerId", b1 =>
                        {
                            b1.Property<Guid>("PlanLocationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PayerId");

                            b1.HasKey("PlanLocationId");

                            b1.ToTable("PlanLocations");

                            b1.WithOwner()
                                .HasForeignKey("PlanLocationId");
                        });

                    b.Navigation("Amount");

                    b.Navigation("CompletionDate");

                    b.Navigation("Images");

                    b.Navigation("PayerId");

                    b.Navigation("PlanLocationUserSpenders");
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