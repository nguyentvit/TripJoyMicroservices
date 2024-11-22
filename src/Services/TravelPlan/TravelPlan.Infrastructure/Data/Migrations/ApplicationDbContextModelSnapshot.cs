﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelPlan.Infrastructure.Data;

#nullable disable

namespace TravelPlan.Infrastructure.Data.Migrations
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
                            Id = new Guid("d1e10f4a-f2dc-4d3e-90da-4c4d0fd80aac"),
                            Name = "An Giang"
                        },
                        new
                        {
                            Id = new Guid("5a0f0a14-63cd-4a28-8675-bc54776b6b85"),
                            Name = "Bà Rịa-Vũng Tàu"
                        },
                        new
                        {
                            Id = new Guid("3bcc8ff9-dad3-4001-ad08-4f90c58bc65d"),
                            Name = "Bắc Giang"
                        },
                        new
                        {
                            Id = new Guid("7e0de925-1825-4ad0-b064-bc69779882ed"),
                            Name = "Bắc Kạn"
                        },
                        new
                        {
                            Id = new Guid("643fad70-f81c-4c66-b44b-8adb08e451aa"),
                            Name = "Bạc Liêu"
                        },
                        new
                        {
                            Id = new Guid("cc3a031e-6b27-4059-b2c6-1181e303bcf5"),
                            Name = "Bắc Ninh"
                        },
                        new
                        {
                            Id = new Guid("770ec7f2-3e32-4076-b06f-970133c74acf"),
                            Name = "Bến Tre"
                        },
                        new
                        {
                            Id = new Guid("27063fc9-2f9f-4471-a52a-8f6a26c681bd"),
                            Name = "Bình Định"
                        },
                        new
                        {
                            Id = new Guid("67220fbe-8aee-4692-a7d5-0df1e6e21d88"),
                            Name = "Bình Dương"
                        },
                        new
                        {
                            Id = new Guid("fad174d7-b306-46fa-a54c-914e28fea1ba"),
                            Name = "Bình Phước"
                        },
                        new
                        {
                            Id = new Guid("50e5043a-98f8-43bf-9a21-f1b6de57cbf4"),
                            Name = "Bình Thuận"
                        },
                        new
                        {
                            Id = new Guid("38fbe3c1-cbd3-4609-976e-ea2b14093776"),
                            Name = "Cà Mau"
                        },
                        new
                        {
                            Id = new Guid("0853974b-1dba-4135-a471-af1153f718a6"),
                            Name = "Cần Thơ"
                        },
                        new
                        {
                            Id = new Guid("9fdb7184-439d-4040-a262-dffc70000609"),
                            Name = "Cao Bằng"
                        },
                        new
                        {
                            Id = new Guid("560459a5-c6ce-4bed-816c-0a74988d5f9b"),
                            Name = "Đà Nẵng"
                        },
                        new
                        {
                            Id = new Guid("62a0f69b-11be-475d-9e86-9e925bbd504f"),
                            Name = "Đắk Lắk"
                        },
                        new
                        {
                            Id = new Guid("d63b8b98-b98c-40ee-814a-20bd332da57a"),
                            Name = "Đắk Nông"
                        },
                        new
                        {
                            Id = new Guid("73e17935-a8d4-4859-9a31-cd1c2c253b35"),
                            Name = "Điện Biên"
                        },
                        new
                        {
                            Id = new Guid("f9813d8c-6c90-4736-819e-c3f04d28e32e"),
                            Name = "Đồng Nai"
                        },
                        new
                        {
                            Id = new Guid("27fcfd70-230b-4a7b-8b7a-7cafad7d989e"),
                            Name = "Đồng Tháp"
                        },
                        new
                        {
                            Id = new Guid("73fea91d-2763-4346-aca7-d7fc4df18444"),
                            Name = "Gia Lai"
                        },
                        new
                        {
                            Id = new Guid("ed6fb11f-17e8-45c7-b1f8-346de52a85aa"),
                            Name = "Hà Giang"
                        },
                        new
                        {
                            Id = new Guid("5033c219-a510-480b-b005-011b28e22752"),
                            Name = "Hà Nam"
                        },
                        new
                        {
                            Id = new Guid("6fbd1b73-34ad-46da-b950-f02d674fb313"),
                            Name = "Hà Nội"
                        },
                        new
                        {
                            Id = new Guid("40629ab7-57a5-4f0f-94bb-0caf600a8a08"),
                            Name = "Hà Tĩnh"
                        },
                        new
                        {
                            Id = new Guid("7f55651d-a444-47d3-9eb4-631704f41f52"),
                            Name = "Hải Dương"
                        },
                        new
                        {
                            Id = new Guid("0a430902-1ba5-43a0-ba11-63d6add6e94c"),
                            Name = "Hải Phòng"
                        },
                        new
                        {
                            Id = new Guid("f6eea8fa-2dcb-4cd5-b9a1-b59eba548a4b"),
                            Name = "Hậu Giang"
                        },
                        new
                        {
                            Id = new Guid("9b2df20c-2604-4415-96fd-8abe29c2a133"),
                            Name = "TP. Hồ Chí Minh"
                        },
                        new
                        {
                            Id = new Guid("5d3dd962-c726-4959-9fa5-7b57e6385452"),
                            Name = "Hòa Bình"
                        },
                        new
                        {
                            Id = new Guid("131c347c-3cc7-42a7-a6f6-0e1990cb0b29"),
                            Name = "Hưng Yên"
                        },
                        new
                        {
                            Id = new Guid("a21552ce-9dea-44bc-99c7-0ecdfd02f3a6"),
                            Name = "Khánh Hòa"
                        },
                        new
                        {
                            Id = new Guid("6c070c17-3f77-48d4-971f-2225e5ce9463"),
                            Name = "Kiên Giang"
                        },
                        new
                        {
                            Id = new Guid("ca0ce86b-2ba3-4beb-84d9-21e1b3d09896"),
                            Name = "Kon Tum"
                        },
                        new
                        {
                            Id = new Guid("b6f499fe-2455-44cd-abb8-f12bea9cc679"),
                            Name = "Lai Châu"
                        },
                        new
                        {
                            Id = new Guid("eb38f8fc-b257-4cfe-99cc-169b24db2c85"),
                            Name = "Lâm Đồng"
                        },
                        new
                        {
                            Id = new Guid("395f71ea-1025-459c-a54f-c7a00ca0bc7b"),
                            Name = "Lạng Sơn"
                        },
                        new
                        {
                            Id = new Guid("4125d441-3341-4d77-baf3-e67b501614fc"),
                            Name = "Lào Cai"
                        },
                        new
                        {
                            Id = new Guid("d3cc4ce4-61c3-4aca-8d7a-2c1cd86a3d11"),
                            Name = "Long An"
                        },
                        new
                        {
                            Id = new Guid("69134f6b-1717-4c3e-8f0f-20cacd30496a"),
                            Name = "Nam Định"
                        },
                        new
                        {
                            Id = new Guid("52185e3e-78e9-48f4-9225-ac1cc86e9028"),
                            Name = "Nghệ An"
                        },
                        new
                        {
                            Id = new Guid("7ed755d7-8a43-4460-aaf1-19a1dd087d6f"),
                            Name = "Ninh Bình"
                        },
                        new
                        {
                            Id = new Guid("14be1b3c-784c-4576-aa59-0c9bc4d87da3"),
                            Name = "Ninh Thuận"
                        },
                        new
                        {
                            Id = new Guid("e69ab6aa-524f-4d70-8e9f-e82600c41e18"),
                            Name = "Phú Thọ"
                        },
                        new
                        {
                            Id = new Guid("baee76f2-8aef-43ff-9ee2-ac741f8cea4c"),
                            Name = "Phú Yên"
                        },
                        new
                        {
                            Id = new Guid("00a62c9d-3d68-484e-a0f3-95cf220764a1"),
                            Name = "Quảng Bình"
                        },
                        new
                        {
                            Id = new Guid("f72efc61-55d3-4878-b48e-ae9ed6f54886"),
                            Name = "Quảng Nam"
                        },
                        new
                        {
                            Id = new Guid("0c3cf51b-8ffb-4030-9667-e52c34b5cea1"),
                            Name = "Quảng Ngãi"
                        },
                        new
                        {
                            Id = new Guid("c52af852-3c15-4820-9554-590647ede7bb"),
                            Name = "Quảng Ninh"
                        },
                        new
                        {
                            Id = new Guid("44b14cba-ce23-4b31-9ada-c929a1c2dcca"),
                            Name = "Quảng Trị"
                        },
                        new
                        {
                            Id = new Guid("877d1f0e-32c4-42db-8bc7-6d571a774135"),
                            Name = "Sóc Trăng"
                        },
                        new
                        {
                            Id = new Guid("67eeee4c-7f67-4ae8-904b-9a08f626a4ae"),
                            Name = "Sơn La"
                        },
                        new
                        {
                            Id = new Guid("0885cf38-9947-4b60-b2b5-71e1f5ce8c97"),
                            Name = "Tây Ninh"
                        },
                        new
                        {
                            Id = new Guid("d69cc249-a1c6-4610-b633-80f0abff82d7"),
                            Name = "Thái Bình"
                        },
                        new
                        {
                            Id = new Guid("8f5620fa-52a1-4df9-8676-bcbda4b9a9af"),
                            Name = "Thái Nguyên"
                        },
                        new
                        {
                            Id = new Guid("5be37a6f-bf19-4cb3-8a02-b3c8ccf6cce2"),
                            Name = "Thanh Hóa"
                        },
                        new
                        {
                            Id = new Guid("87204733-61b1-4cef-ae7d-025d326709bf"),
                            Name = "Thừa Thiên - Huế"
                        },
                        new
                        {
                            Id = new Guid("63d2f65d-0490-4979-a466-4d3e6788c8bb"),
                            Name = "Tiền Giang"
                        },
                        new
                        {
                            Id = new Guid("f30d32fe-ced2-4e1f-a718-29fd49374427"),
                            Name = "Trà Vinh"
                        },
                        new
                        {
                            Id = new Guid("26980a90-d6a5-4f83-be52-cb0d8ebceee9"),
                            Name = "Tuyên Quang"
                        },
                        new
                        {
                            Id = new Guid("e127615d-f223-4bdc-a441-32df1e4bd6ec"),
                            Name = "Vĩnh Long"
                        },
                        new
                        {
                            Id = new Guid("275c5756-ec6e-47be-b8fd-c861bd816a2b"),
                            Name = "Vĩnh Phúc"
                        },
                        new
                        {
                            Id = new Guid("34e9002e-1abe-44e5-af99-cd2628fae946"),
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
