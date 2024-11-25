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
    [Migration("20241122185914_Update-TravelPlan-Spender")]
    partial class UpdateTravelPlanSpender
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
                            Id = new Guid("8f3e199c-7df3-48f9-8d3b-c0f92f6b9c89"),
                            Name = "An Giang"
                        },
                        new
                        {
                            Id = new Guid("15fceb9b-ce0f-4efb-8c23-86cadc970889"),
                            Name = "Bà Rịa-Vũng Tàu"
                        },
                        new
                        {
                            Id = new Guid("ca758f7c-0517-491b-841a-85d49aa39c33"),
                            Name = "Bắc Giang"
                        },
                        new
                        {
                            Id = new Guid("9793eea3-b43d-4490-b815-637b98c85d46"),
                            Name = "Bắc Kạn"
                        },
                        new
                        {
                            Id = new Guid("660f01b2-13fb-4d1f-b57c-773e5f8d809c"),
                            Name = "Bạc Liêu"
                        },
                        new
                        {
                            Id = new Guid("db884ace-036e-40a1-9986-08fef43caaa5"),
                            Name = "Bắc Ninh"
                        },
                        new
                        {
                            Id = new Guid("09e08229-81f0-4172-98d8-98a7881fdb95"),
                            Name = "Bến Tre"
                        },
                        new
                        {
                            Id = new Guid("310dd68b-b8c7-4931-a552-0bf130d7ad8f"),
                            Name = "Bình Định"
                        },
                        new
                        {
                            Id = new Guid("62e252bc-009e-4bf0-921e-f688933c169b"),
                            Name = "Bình Dương"
                        },
                        new
                        {
                            Id = new Guid("c0f2551a-0bd3-4c24-99bc-f1cfa968c704"),
                            Name = "Bình Phước"
                        },
                        new
                        {
                            Id = new Guid("fd4392b3-4b0f-4486-b8d4-8da26278a018"),
                            Name = "Bình Thuận"
                        },
                        new
                        {
                            Id = new Guid("ee807ac1-173b-4e51-b002-e2c9f1b6b30e"),
                            Name = "Cà Mau"
                        },
                        new
                        {
                            Id = new Guid("9c9eb32f-8865-423e-b681-af352f32625c"),
                            Name = "Cần Thơ"
                        },
                        new
                        {
                            Id = new Guid("682da0ed-c4a5-4ffd-ada0-9671cc5495ac"),
                            Name = "Cao Bằng"
                        },
                        new
                        {
                            Id = new Guid("ddd1520b-1e90-466b-91b2-a3b13e54402a"),
                            Name = "Đà Nẵng"
                        },
                        new
                        {
                            Id = new Guid("5669fd04-c289-4c29-97d1-96b76aff6ca2"),
                            Name = "Đắk Lắk"
                        },
                        new
                        {
                            Id = new Guid("9671c1f8-5757-45a3-bbb7-9880a816b45c"),
                            Name = "Đắk Nông"
                        },
                        new
                        {
                            Id = new Guid("7e93ab63-999d-4136-a10a-abd78e6cb17b"),
                            Name = "Điện Biên"
                        },
                        new
                        {
                            Id = new Guid("3f852af4-cb8c-4318-a37a-b8f3b24f10e0"),
                            Name = "Đồng Nai"
                        },
                        new
                        {
                            Id = new Guid("612cf36a-0497-4c50-9b54-54c02046ac8c"),
                            Name = "Đồng Tháp"
                        },
                        new
                        {
                            Id = new Guid("5aa84168-a959-4659-83bb-adfae9a7f6b5"),
                            Name = "Gia Lai"
                        },
                        new
                        {
                            Id = new Guid("0d99329c-7428-41b6-96a6-d62efa918631"),
                            Name = "Hà Giang"
                        },
                        new
                        {
                            Id = new Guid("1dd76308-8b42-4cc3-9163-109d33fa0ff1"),
                            Name = "Hà Nam"
                        },
                        new
                        {
                            Id = new Guid("bac51211-cfb2-4f15-9520-ca282851009b"),
                            Name = "Hà Nội"
                        },
                        new
                        {
                            Id = new Guid("0d58c96c-d317-47ea-96db-fe825d2cc3a5"),
                            Name = "Hà Tĩnh"
                        },
                        new
                        {
                            Id = new Guid("a5ed0117-7a3b-44c0-9e32-fdc69078c1a2"),
                            Name = "Hải Dương"
                        },
                        new
                        {
                            Id = new Guid("8e4a5e3c-1de4-4011-be50-f0513142a739"),
                            Name = "Hải Phòng"
                        },
                        new
                        {
                            Id = new Guid("7df6ef36-3860-492a-8e00-491f5fc647b5"),
                            Name = "Hậu Giang"
                        },
                        new
                        {
                            Id = new Guid("df1140ca-80a4-4b92-a907-61e3ff382803"),
                            Name = "TP. Hồ Chí Minh"
                        },
                        new
                        {
                            Id = new Guid("eeba8f3f-2dc0-42a8-b03c-57fc41e51c42"),
                            Name = "Hòa Bình"
                        },
                        new
                        {
                            Id = new Guid("0d2ddbf8-d373-4bac-abb5-63fda0b763c4"),
                            Name = "Hưng Yên"
                        },
                        new
                        {
                            Id = new Guid("5b6e7e7a-42bd-4b4d-b3a2-da61a08f367e"),
                            Name = "Khánh Hòa"
                        },
                        new
                        {
                            Id = new Guid("fe58f725-9870-4670-ba40-4e2ee085a866"),
                            Name = "Kiên Giang"
                        },
                        new
                        {
                            Id = new Guid("e51617de-d9eb-4add-81bd-eda9a88aa21a"),
                            Name = "Kon Tum"
                        },
                        new
                        {
                            Id = new Guid("3a152b1d-af9a-483f-bbb2-67948a276831"),
                            Name = "Lai Châu"
                        },
                        new
                        {
                            Id = new Guid("ceaeefb0-f68b-4d24-aed0-a628120b11eb"),
                            Name = "Lâm Đồng"
                        },
                        new
                        {
                            Id = new Guid("c1d0e4ca-843d-4593-a6ff-661f89974b04"),
                            Name = "Lạng Sơn"
                        },
                        new
                        {
                            Id = new Guid("e6381095-eae1-4755-a9d8-d24715689b26"),
                            Name = "Lào Cai"
                        },
                        new
                        {
                            Id = new Guid("d2f6ead2-02de-4952-af12-4e3ef69d4823"),
                            Name = "Long An"
                        },
                        new
                        {
                            Id = new Guid("3983aa51-d2f0-435d-8524-688bd1d29e52"),
                            Name = "Nam Định"
                        },
                        new
                        {
                            Id = new Guid("374c556f-0159-486c-8c1a-b9a0f83d63ed"),
                            Name = "Nghệ An"
                        },
                        new
                        {
                            Id = new Guid("61bb83da-c6ec-4533-8d72-4069da531110"),
                            Name = "Ninh Bình"
                        },
                        new
                        {
                            Id = new Guid("11bd9cc7-913a-442e-ac48-d05d4e2450c1"),
                            Name = "Ninh Thuận"
                        },
                        new
                        {
                            Id = new Guid("7e1f4ac7-9c3a-4979-969e-e61e49970825"),
                            Name = "Phú Thọ"
                        },
                        new
                        {
                            Id = new Guid("940ed2b0-8e27-4037-b6c1-b151ed94c11a"),
                            Name = "Phú Yên"
                        },
                        new
                        {
                            Id = new Guid("063a8994-cdae-47ba-bea9-eed3b8dda901"),
                            Name = "Quảng Bình"
                        },
                        new
                        {
                            Id = new Guid("96f70996-e93e-4a68-851e-93a42b4d0c13"),
                            Name = "Quảng Nam"
                        },
                        new
                        {
                            Id = new Guid("e9d7157b-cb50-48d4-b487-c2295054cbd6"),
                            Name = "Quảng Ngãi"
                        },
                        new
                        {
                            Id = new Guid("5ee09697-1a4d-4023-aef8-535fae3257b9"),
                            Name = "Quảng Ninh"
                        },
                        new
                        {
                            Id = new Guid("09911531-6d5c-4982-a7dd-57046c42c98b"),
                            Name = "Quảng Trị"
                        },
                        new
                        {
                            Id = new Guid("edd07afe-26f2-486a-81bf-10dbfb2cacb2"),
                            Name = "Sóc Trăng"
                        },
                        new
                        {
                            Id = new Guid("0595b30b-89f6-4e52-9cc4-1c6ea91643e5"),
                            Name = "Sơn La"
                        },
                        new
                        {
                            Id = new Guid("32ff1973-14f7-479a-9705-6ce085210881"),
                            Name = "Tây Ninh"
                        },
                        new
                        {
                            Id = new Guid("d40a722d-ec6d-428f-b584-c7fa226d79a8"),
                            Name = "Thái Bình"
                        },
                        new
                        {
                            Id = new Guid("52259187-e872-4b7b-991c-9633b208c36b"),
                            Name = "Thái Nguyên"
                        },
                        new
                        {
                            Id = new Guid("65fd2f2b-a79f-463e-800c-348cb642ab09"),
                            Name = "Thanh Hóa"
                        },
                        new
                        {
                            Id = new Guid("81d73229-3fb4-43d5-bbf9-f57060ebdf14"),
                            Name = "Thừa Thiên - Huế"
                        },
                        new
                        {
                            Id = new Guid("b5e4123e-7088-4b80-a5d5-a47a39cad48d"),
                            Name = "Tiền Giang"
                        },
                        new
                        {
                            Id = new Guid("4a6c4ee7-a522-4bc3-83c8-b39b5ba52830"),
                            Name = "Trà Vinh"
                        },
                        new
                        {
                            Id = new Guid("f3e450ca-1440-42e0-8ab7-6be64a0808d6"),
                            Name = "Tuyên Quang"
                        },
                        new
                        {
                            Id = new Guid("aa1814c7-b151-4377-ab47-08be787ae518"),
                            Name = "Vĩnh Long"
                        },
                        new
                        {
                            Id = new Guid("e7e38be5-dd11-4617-9663-6ad8b0297c3e"),
                            Name = "Vĩnh Phúc"
                        },
                        new
                        {
                            Id = new Guid("7b716c50-6c9b-468c-94e2-285176ed138b"),
                            Name = "Yên Bái"
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