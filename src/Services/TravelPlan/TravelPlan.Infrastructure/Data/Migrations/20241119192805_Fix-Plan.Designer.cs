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
    [Migration("20241119192805_Fix-Plan")]
    partial class FixPlan
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
                            Id = new Guid("ca8b1b7e-3179-4a7f-ab6f-977039439f48"),
                            Name = "An Giang"
                        },
                        new
                        {
                            Id = new Guid("e27c0231-c07f-4002-95d6-953157d25a53"),
                            Name = "Bà Rịa-Vũng Tàu"
                        },
                        new
                        {
                            Id = new Guid("69b79878-33e5-4982-9f8d-061149751db2"),
                            Name = "Bắc Giang"
                        },
                        new
                        {
                            Id = new Guid("28ef865d-0c27-4600-9030-36339b6921a6"),
                            Name = "Bắc Kạn"
                        },
                        new
                        {
                            Id = new Guid("12e7c647-e56e-4ff2-be33-9b3c7995fb66"),
                            Name = "Bạc Liêu"
                        },
                        new
                        {
                            Id = new Guid("b4a71ae1-41f9-4a6e-8091-278842989731"),
                            Name = "Bắc Ninh"
                        },
                        new
                        {
                            Id = new Guid("8c0bd4e2-420b-43df-b9dd-a0c9e43ee0a2"),
                            Name = "Bến Tre"
                        },
                        new
                        {
                            Id = new Guid("35bfd1b1-6fa9-436e-9787-0a844bf9ea96"),
                            Name = "Bình Định"
                        },
                        new
                        {
                            Id = new Guid("339a55cd-a94a-436d-907b-41e607d472a2"),
                            Name = "Bình Dương"
                        },
                        new
                        {
                            Id = new Guid("80d0b06b-5929-49d1-84e3-e30be21cfd64"),
                            Name = "Bình Phước"
                        },
                        new
                        {
                            Id = new Guid("4ce6c838-5fb5-4310-940b-04aa16cf9537"),
                            Name = "Bình Thuận"
                        },
                        new
                        {
                            Id = new Guid("8876732b-cb72-4d25-a7c7-8e89a6cbbb74"),
                            Name = "Cà Mau"
                        },
                        new
                        {
                            Id = new Guid("a67ebc2b-851f-4ad4-a8c2-f463d985a0b0"),
                            Name = "Cần Thơ"
                        },
                        new
                        {
                            Id = new Guid("3dc46f6c-9396-45c0-876a-d1f6f545fa00"),
                            Name = "Cao Bằng"
                        },
                        new
                        {
                            Id = new Guid("bf313f60-4bbd-4cf8-9f2f-20cd313e6c67"),
                            Name = "Đà Nẵng"
                        },
                        new
                        {
                            Id = new Guid("18a454ff-baa3-480c-a251-5e877bb3327a"),
                            Name = "Đắk Lắk"
                        },
                        new
                        {
                            Id = new Guid("761e254b-8b02-4be8-b918-e7d28b27eec4"),
                            Name = "Đắk Nông"
                        },
                        new
                        {
                            Id = new Guid("4ed638f5-55a3-4213-8f2d-7bb1e531cbff"),
                            Name = "Điện Biên"
                        },
                        new
                        {
                            Id = new Guid("74ee15f6-acf1-4870-9770-024bbcb2b8a5"),
                            Name = "Đồng Nai"
                        },
                        new
                        {
                            Id = new Guid("1900963f-bf8e-487a-b23d-ec2f07c39a41"),
                            Name = "Đồng Tháp"
                        },
                        new
                        {
                            Id = new Guid("39761c2a-2b98-429b-8522-3cc75cc64caf"),
                            Name = "Gia Lai"
                        },
                        new
                        {
                            Id = new Guid("02b47fe6-5c30-42b2-bb2c-04f0fca94832"),
                            Name = "Hà Giang"
                        },
                        new
                        {
                            Id = new Guid("b4c1f11e-14f1-4509-972f-87b6f5277a41"),
                            Name = "Hà Nam"
                        },
                        new
                        {
                            Id = new Guid("fb4a2864-0f33-4e8e-9e07-7c4d30b80e3c"),
                            Name = "Hà Nội"
                        },
                        new
                        {
                            Id = new Guid("fbf78960-4f03-40b5-84d9-21c503cd7209"),
                            Name = "Hà Tĩnh"
                        },
                        new
                        {
                            Id = new Guid("25a1d71b-d0ea-4fe5-b395-598880f310b9"),
                            Name = "Hải Dương"
                        },
                        new
                        {
                            Id = new Guid("91d593f3-cc16-4847-98bd-6c2850f6ed17"),
                            Name = "Hải Phòng"
                        },
                        new
                        {
                            Id = new Guid("b4e6edc4-868e-48c3-a524-7b6f2d23c74d"),
                            Name = "Hậu Giang"
                        },
                        new
                        {
                            Id = new Guid("7f997052-9a15-4a4e-a03d-9e6ef40b25e8"),
                            Name = "TP. Hồ Chí Minh"
                        },
                        new
                        {
                            Id = new Guid("c26aeea7-4e12-4b56-b709-bfffb0916495"),
                            Name = "Hòa Bình"
                        },
                        new
                        {
                            Id = new Guid("283d74cc-abfa-4b18-8d25-4ac8299331e0"),
                            Name = "Hưng Yên"
                        },
                        new
                        {
                            Id = new Guid("ad5f7066-0c0a-4548-9046-3ef47a81d4a0"),
                            Name = "Khánh Hòa"
                        },
                        new
                        {
                            Id = new Guid("348f328a-727e-45ca-b645-4f0a0877bb83"),
                            Name = "Kiên Giang"
                        },
                        new
                        {
                            Id = new Guid("af539f1c-b0f6-4459-be14-4720f56578a1"),
                            Name = "Kon Tum"
                        },
                        new
                        {
                            Id = new Guid("a7f58a76-6728-4a19-93ac-591ddea7d9a6"),
                            Name = "Lai Châu"
                        },
                        new
                        {
                            Id = new Guid("e627fc44-0d33-41e2-8025-c6506ddabf0d"),
                            Name = "Lâm Đồng"
                        },
                        new
                        {
                            Id = new Guid("0286f3ad-812c-4512-9546-26086086f814"),
                            Name = "Lạng Sơn"
                        },
                        new
                        {
                            Id = new Guid("47478c27-863f-4e69-9ac6-067e6d194cee"),
                            Name = "Lào Cai"
                        },
                        new
                        {
                            Id = new Guid("08b14fe5-5838-4897-a929-612bd662775e"),
                            Name = "Long An"
                        },
                        new
                        {
                            Id = new Guid("04c5e68f-bbc3-47c8-900a-d9c775480265"),
                            Name = "Nam Định"
                        },
                        new
                        {
                            Id = new Guid("5f4df01e-8d9a-48db-9772-bfea00cb491d"),
                            Name = "Nghệ An"
                        },
                        new
                        {
                            Id = new Guid("6de4373a-c46f-44b4-b8e9-ac0b23ef5aae"),
                            Name = "Ninh Bình"
                        },
                        new
                        {
                            Id = new Guid("7d2bd56a-4de1-4655-b944-7dcf37b1925a"),
                            Name = "Ninh Thuận"
                        },
                        new
                        {
                            Id = new Guid("5f9c8bdf-ec93-4a63-b519-b44e478ea750"),
                            Name = "Phú Thọ"
                        },
                        new
                        {
                            Id = new Guid("a5322e66-5cd5-4545-ae1d-3d27ab2f9901"),
                            Name = "Phú Yên"
                        },
                        new
                        {
                            Id = new Guid("bf11e69e-9010-4773-a91d-bf95df55578b"),
                            Name = "Quảng Bình"
                        },
                        new
                        {
                            Id = new Guid("96b7ad8c-0693-4721-8237-1f2e42664d78"),
                            Name = "Quảng Nam"
                        },
                        new
                        {
                            Id = new Guid("6bdabd6f-3263-4a14-872c-2a6c17d5de07"),
                            Name = "Quảng Ngãi"
                        },
                        new
                        {
                            Id = new Guid("6f64603c-4185-43c6-bc2d-9ae44b0dcb71"),
                            Name = "Quảng Ninh"
                        },
                        new
                        {
                            Id = new Guid("31e662cf-7c2e-4477-acac-21bb625481f1"),
                            Name = "Quảng Trị"
                        },
                        new
                        {
                            Id = new Guid("b313cffc-edc6-42d4-9195-1c17afc66334"),
                            Name = "Sóc Trăng"
                        },
                        new
                        {
                            Id = new Guid("217b0e37-5c4b-4315-a9d2-534a3f0bc974"),
                            Name = "Sơn La"
                        },
                        new
                        {
                            Id = new Guid("fc4440e8-c5af-46b4-8c5d-88098f2cb5c3"),
                            Name = "Tây Ninh"
                        },
                        new
                        {
                            Id = new Guid("5b96908c-5ec8-486f-92d7-dd5e5abf7349"),
                            Name = "Thái Bình"
                        },
                        new
                        {
                            Id = new Guid("c5571362-18db-4aa2-be04-b061578a2f01"),
                            Name = "Thái Nguyên"
                        },
                        new
                        {
                            Id = new Guid("805f10d2-8edd-4e7d-8b76-6cdd0ff649fb"),
                            Name = "Thanh Hóa"
                        },
                        new
                        {
                            Id = new Guid("35d44b36-41dc-4b4a-989f-6dfeb21ce519"),
                            Name = "Thừa Thiên - Huế"
                        },
                        new
                        {
                            Id = new Guid("f66964d6-2fb5-48da-98e4-d572469db3d9"),
                            Name = "Tiền Giang"
                        },
                        new
                        {
                            Id = new Guid("c6d825f4-153d-47b2-a811-f253979b97c5"),
                            Name = "Trà Vinh"
                        },
                        new
                        {
                            Id = new Guid("1e04319a-6cb3-4b01-8bdb-143d189372ab"),
                            Name = "Tuyên Quang"
                        },
                        new
                        {
                            Id = new Guid("d9e2dd13-b892-4a80-af84-8e55ac2daa1c"),
                            Name = "Vĩnh Long"
                        },
                        new
                        {
                            Id = new Guid("76f9e470-282b-4cb2-b5da-ed9ecb41f271"),
                            Name = "Vĩnh Phúc"
                        },
                        new
                        {
                            Id = new Guid("059358f1-704f-4644-bdd2-c45ce4781417"),
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
