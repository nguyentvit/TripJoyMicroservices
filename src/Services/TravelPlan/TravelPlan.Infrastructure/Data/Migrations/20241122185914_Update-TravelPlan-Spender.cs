using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelPlan.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTravelPlanSpender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanLocationExpense");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("00a62c9d-3d68-484e-a0f3-95cf220764a1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0853974b-1dba-4135-a471-af1153f718a6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0885cf38-9947-4b60-b2b5-71e1f5ce8c97"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0a430902-1ba5-43a0-ba11-63d6add6e94c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0c3cf51b-8ffb-4030-9667-e52c34b5cea1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("131c347c-3cc7-42a7-a6f6-0e1990cb0b29"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("14be1b3c-784c-4576-aa59-0c9bc4d87da3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("26980a90-d6a5-4f83-be52-cb0d8ebceee9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("27063fc9-2f9f-4471-a52a-8f6a26c681bd"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("275c5756-ec6e-47be-b8fd-c861bd816a2b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("27fcfd70-230b-4a7b-8b7a-7cafad7d989e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("34e9002e-1abe-44e5-af99-cd2628fae946"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("38fbe3c1-cbd3-4609-976e-ea2b14093776"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("395f71ea-1025-459c-a54f-c7a00ca0bc7b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3bcc8ff9-dad3-4001-ad08-4f90c58bc65d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("40629ab7-57a5-4f0f-94bb-0caf600a8a08"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4125d441-3341-4d77-baf3-e67b501614fc"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("44b14cba-ce23-4b31-9ada-c929a1c2dcca"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5033c219-a510-480b-b005-011b28e22752"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("50e5043a-98f8-43bf-9a21-f1b6de57cbf4"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("52185e3e-78e9-48f4-9225-ac1cc86e9028"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("560459a5-c6ce-4bed-816c-0a74988d5f9b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5a0f0a14-63cd-4a28-8675-bc54776b6b85"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5be37a6f-bf19-4cb3-8a02-b3c8ccf6cce2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5d3dd962-c726-4959-9fa5-7b57e6385452"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("62a0f69b-11be-475d-9e86-9e925bbd504f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("63d2f65d-0490-4979-a466-4d3e6788c8bb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("643fad70-f81c-4c66-b44b-8adb08e451aa"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("67220fbe-8aee-4692-a7d5-0df1e6e21d88"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("67eeee4c-7f67-4ae8-904b-9a08f626a4ae"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("69134f6b-1717-4c3e-8f0f-20cacd30496a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6c070c17-3f77-48d4-971f-2225e5ce9463"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6fbd1b73-34ad-46da-b950-f02d674fb313"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("73e17935-a8d4-4859-9a31-cd1c2c253b35"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("73fea91d-2763-4346-aca7-d7fc4df18444"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("770ec7f2-3e32-4076-b06f-970133c74acf"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7e0de925-1825-4ad0-b064-bc69779882ed"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7ed755d7-8a43-4460-aaf1-19a1dd087d6f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7f55651d-a444-47d3-9eb4-631704f41f52"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("87204733-61b1-4cef-ae7d-025d326709bf"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("877d1f0e-32c4-42db-8bc7-6d571a774135"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8f5620fa-52a1-4df9-8676-bcbda4b9a9af"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9b2df20c-2604-4415-96fd-8abe29c2a133"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9fdb7184-439d-4040-a262-dffc70000609"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a21552ce-9dea-44bc-99c7-0ecdfd02f3a6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b6f499fe-2455-44cd-abb8-f12bea9cc679"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("baee76f2-8aef-43ff-9ee2-ac741f8cea4c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c52af852-3c15-4820-9554-590647ede7bb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ca0ce86b-2ba3-4beb-84d9-21e1b3d09896"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("cc3a031e-6b27-4059-b2c6-1181e303bcf5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d1e10f4a-f2dc-4d3e-90da-4c4d0fd80aac"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d3cc4ce4-61c3-4aca-8d7a-2c1cd86a3d11"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d63b8b98-b98c-40ee-814a-20bd332da57a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d69cc249-a1c6-4610-b633-80f0abff82d7"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e127615d-f223-4bdc-a441-32df1e4bd6ec"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e69ab6aa-524f-4d70-8e9f-e82600c41e18"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("eb38f8fc-b257-4cfe-99cc-169b24db2c85"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ed6fb11f-17e8-45c7-b1f8-346de52a85aa"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f30d32fe-ced2-4e1f-a718-29fd49374427"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f6eea8fa-2dcb-4cd5-b9a1-b59eba548a4b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f72efc61-55d3-4878-b48e-ae9ed6f54886"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f9813d8c-6c90-4736-819e-c3f04d28e32e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fad174d7-b306-46fa-a54c-914e28fea1ba"));

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PlanLocations",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PayerId",
                table: "PlanLocations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlanLocationUserSpender",
                columns: table => new
                {
                    PlanLocationUserSpenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserSpenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanLocationUserSpender", x => new { x.PlanLocationUserSpenderId, x.PlanLocationId });
                    table.ForeignKey(
                        name: "FK_PlanLocationUserSpender_PlanLocations_PlanLocationId",
                        column: x => x.PlanLocationId,
                        principalTable: "PlanLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("0595b30b-89f6-4e52-9cc4-1c6ea91643e5"), null, null, null, null, "Sơn La" },
                    { new Guid("063a8994-cdae-47ba-bea9-eed3b8dda901"), null, null, null, null, "Quảng Bình" },
                    { new Guid("09911531-6d5c-4982-a7dd-57046c42c98b"), null, null, null, null, "Quảng Trị" },
                    { new Guid("09e08229-81f0-4172-98d8-98a7881fdb95"), null, null, null, null, "Bến Tre" },
                    { new Guid("0d2ddbf8-d373-4bac-abb5-63fda0b763c4"), null, null, null, null, "Hưng Yên" },
                    { new Guid("0d58c96c-d317-47ea-96db-fe825d2cc3a5"), null, null, null, null, "Hà Tĩnh" },
                    { new Guid("0d99329c-7428-41b6-96a6-d62efa918631"), null, null, null, null, "Hà Giang" },
                    { new Guid("11bd9cc7-913a-442e-ac48-d05d4e2450c1"), null, null, null, null, "Ninh Thuận" },
                    { new Guid("15fceb9b-ce0f-4efb-8c23-86cadc970889"), null, null, null, null, "Bà Rịa-Vũng Tàu" },
                    { new Guid("1dd76308-8b42-4cc3-9163-109d33fa0ff1"), null, null, null, null, "Hà Nam" },
                    { new Guid("310dd68b-b8c7-4931-a552-0bf130d7ad8f"), null, null, null, null, "Bình Định" },
                    { new Guid("32ff1973-14f7-479a-9705-6ce085210881"), null, null, null, null, "Tây Ninh" },
                    { new Guid("374c556f-0159-486c-8c1a-b9a0f83d63ed"), null, null, null, null, "Nghệ An" },
                    { new Guid("3983aa51-d2f0-435d-8524-688bd1d29e52"), null, null, null, null, "Nam Định" },
                    { new Guid("3a152b1d-af9a-483f-bbb2-67948a276831"), null, null, null, null, "Lai Châu" },
                    { new Guid("3f852af4-cb8c-4318-a37a-b8f3b24f10e0"), null, null, null, null, "Đồng Nai" },
                    { new Guid("4a6c4ee7-a522-4bc3-83c8-b39b5ba52830"), null, null, null, null, "Trà Vinh" },
                    { new Guid("52259187-e872-4b7b-991c-9633b208c36b"), null, null, null, null, "Thái Nguyên" },
                    { new Guid("5669fd04-c289-4c29-97d1-96b76aff6ca2"), null, null, null, null, "Đắk Lắk" },
                    { new Guid("5aa84168-a959-4659-83bb-adfae9a7f6b5"), null, null, null, null, "Gia Lai" },
                    { new Guid("5b6e7e7a-42bd-4b4d-b3a2-da61a08f367e"), null, null, null, null, "Khánh Hòa" },
                    { new Guid("5ee09697-1a4d-4023-aef8-535fae3257b9"), null, null, null, null, "Quảng Ninh" },
                    { new Guid("612cf36a-0497-4c50-9b54-54c02046ac8c"), null, null, null, null, "Đồng Tháp" },
                    { new Guid("61bb83da-c6ec-4533-8d72-4069da531110"), null, null, null, null, "Ninh Bình" },
                    { new Guid("62e252bc-009e-4bf0-921e-f688933c169b"), null, null, null, null, "Bình Dương" },
                    { new Guid("65fd2f2b-a79f-463e-800c-348cb642ab09"), null, null, null, null, "Thanh Hóa" },
                    { new Guid("660f01b2-13fb-4d1f-b57c-773e5f8d809c"), null, null, null, null, "Bạc Liêu" },
                    { new Guid("682da0ed-c4a5-4ffd-ada0-9671cc5495ac"), null, null, null, null, "Cao Bằng" },
                    { new Guid("7b716c50-6c9b-468c-94e2-285176ed138b"), null, null, null, null, "Yên Bái" },
                    { new Guid("7df6ef36-3860-492a-8e00-491f5fc647b5"), null, null, null, null, "Hậu Giang" },
                    { new Guid("7e1f4ac7-9c3a-4979-969e-e61e49970825"), null, null, null, null, "Phú Thọ" },
                    { new Guid("7e93ab63-999d-4136-a10a-abd78e6cb17b"), null, null, null, null, "Điện Biên" },
                    { new Guid("81d73229-3fb4-43d5-bbf9-f57060ebdf14"), null, null, null, null, "Thừa Thiên - Huế" },
                    { new Guid("8e4a5e3c-1de4-4011-be50-f0513142a739"), null, null, null, null, "Hải Phòng" },
                    { new Guid("8f3e199c-7df3-48f9-8d3b-c0f92f6b9c89"), null, null, null, null, "An Giang" },
                    { new Guid("940ed2b0-8e27-4037-b6c1-b151ed94c11a"), null, null, null, null, "Phú Yên" },
                    { new Guid("9671c1f8-5757-45a3-bbb7-9880a816b45c"), null, null, null, null, "Đắk Nông" },
                    { new Guid("96f70996-e93e-4a68-851e-93a42b4d0c13"), null, null, null, null, "Quảng Nam" },
                    { new Guid("9793eea3-b43d-4490-b815-637b98c85d46"), null, null, null, null, "Bắc Kạn" },
                    { new Guid("9c9eb32f-8865-423e-b681-af352f32625c"), null, null, null, null, "Cần Thơ" },
                    { new Guid("a5ed0117-7a3b-44c0-9e32-fdc69078c1a2"), null, null, null, null, "Hải Dương" },
                    { new Guid("aa1814c7-b151-4377-ab47-08be787ae518"), null, null, null, null, "Vĩnh Long" },
                    { new Guid("b5e4123e-7088-4b80-a5d5-a47a39cad48d"), null, null, null, null, "Tiền Giang" },
                    { new Guid("bac51211-cfb2-4f15-9520-ca282851009b"), null, null, null, null, "Hà Nội" },
                    { new Guid("c0f2551a-0bd3-4c24-99bc-f1cfa968c704"), null, null, null, null, "Bình Phước" },
                    { new Guid("c1d0e4ca-843d-4593-a6ff-661f89974b04"), null, null, null, null, "Lạng Sơn" },
                    { new Guid("ca758f7c-0517-491b-841a-85d49aa39c33"), null, null, null, null, "Bắc Giang" },
                    { new Guid("ceaeefb0-f68b-4d24-aed0-a628120b11eb"), null, null, null, null, "Lâm Đồng" },
                    { new Guid("d2f6ead2-02de-4952-af12-4e3ef69d4823"), null, null, null, null, "Long An" },
                    { new Guid("d40a722d-ec6d-428f-b584-c7fa226d79a8"), null, null, null, null, "Thái Bình" },
                    { new Guid("db884ace-036e-40a1-9986-08fef43caaa5"), null, null, null, null, "Bắc Ninh" },
                    { new Guid("ddd1520b-1e90-466b-91b2-a3b13e54402a"), null, null, null, null, "Đà Nẵng" },
                    { new Guid("df1140ca-80a4-4b92-a907-61e3ff382803"), null, null, null, null, "TP. Hồ Chí Minh" },
                    { new Guid("e51617de-d9eb-4add-81bd-eda9a88aa21a"), null, null, null, null, "Kon Tum" },
                    { new Guid("e6381095-eae1-4755-a9d8-d24715689b26"), null, null, null, null, "Lào Cai" },
                    { new Guid("e7e38be5-dd11-4617-9663-6ad8b0297c3e"), null, null, null, null, "Vĩnh Phúc" },
                    { new Guid("e9d7157b-cb50-48d4-b487-c2295054cbd6"), null, null, null, null, "Quảng Ngãi" },
                    { new Guid("edd07afe-26f2-486a-81bf-10dbfb2cacb2"), null, null, null, null, "Sóc Trăng" },
                    { new Guid("ee807ac1-173b-4e51-b002-e2c9f1b6b30e"), null, null, null, null, "Cà Mau" },
                    { new Guid("eeba8f3f-2dc0-42a8-b03c-57fc41e51c42"), null, null, null, null, "Hòa Bình" },
                    { new Guid("f3e450ca-1440-42e0-8ab7-6be64a0808d6"), null, null, null, null, "Tuyên Quang" },
                    { new Guid("fd4392b3-4b0f-4486-b8d4-8da26278a018"), null, null, null, null, "Bình Thuận" },
                    { new Guid("fe58f725-9870-4670-ba40-4e2ee085a866"), null, null, null, null, "Kiên Giang" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanLocationUserSpender_PlanLocationId",
                table: "PlanLocationUserSpender",
                column: "PlanLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanLocationUserSpender");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0595b30b-89f6-4e52-9cc4-1c6ea91643e5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("063a8994-cdae-47ba-bea9-eed3b8dda901"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("09911531-6d5c-4982-a7dd-57046c42c98b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("09e08229-81f0-4172-98d8-98a7881fdb95"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0d2ddbf8-d373-4bac-abb5-63fda0b763c4"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0d58c96c-d317-47ea-96db-fe825d2cc3a5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0d99329c-7428-41b6-96a6-d62efa918631"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("11bd9cc7-913a-442e-ac48-d05d4e2450c1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("15fceb9b-ce0f-4efb-8c23-86cadc970889"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1dd76308-8b42-4cc3-9163-109d33fa0ff1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("310dd68b-b8c7-4931-a552-0bf130d7ad8f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("32ff1973-14f7-479a-9705-6ce085210881"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("374c556f-0159-486c-8c1a-b9a0f83d63ed"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3983aa51-d2f0-435d-8524-688bd1d29e52"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3a152b1d-af9a-483f-bbb2-67948a276831"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3f852af4-cb8c-4318-a37a-b8f3b24f10e0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4a6c4ee7-a522-4bc3-83c8-b39b5ba52830"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("52259187-e872-4b7b-991c-9633b208c36b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5669fd04-c289-4c29-97d1-96b76aff6ca2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5aa84168-a959-4659-83bb-adfae9a7f6b5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5b6e7e7a-42bd-4b4d-b3a2-da61a08f367e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5ee09697-1a4d-4023-aef8-535fae3257b9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("612cf36a-0497-4c50-9b54-54c02046ac8c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("61bb83da-c6ec-4533-8d72-4069da531110"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("62e252bc-009e-4bf0-921e-f688933c169b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("65fd2f2b-a79f-463e-800c-348cb642ab09"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("660f01b2-13fb-4d1f-b57c-773e5f8d809c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("682da0ed-c4a5-4ffd-ada0-9671cc5495ac"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7b716c50-6c9b-468c-94e2-285176ed138b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7df6ef36-3860-492a-8e00-491f5fc647b5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7e1f4ac7-9c3a-4979-969e-e61e49970825"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7e93ab63-999d-4136-a10a-abd78e6cb17b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("81d73229-3fb4-43d5-bbf9-f57060ebdf14"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8e4a5e3c-1de4-4011-be50-f0513142a739"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8f3e199c-7df3-48f9-8d3b-c0f92f6b9c89"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("940ed2b0-8e27-4037-b6c1-b151ed94c11a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9671c1f8-5757-45a3-bbb7-9880a816b45c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("96f70996-e93e-4a68-851e-93a42b4d0c13"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9793eea3-b43d-4490-b815-637b98c85d46"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9c9eb32f-8865-423e-b681-af352f32625c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a5ed0117-7a3b-44c0-9e32-fdc69078c1a2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("aa1814c7-b151-4377-ab47-08be787ae518"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b5e4123e-7088-4b80-a5d5-a47a39cad48d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("bac51211-cfb2-4f15-9520-ca282851009b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c0f2551a-0bd3-4c24-99bc-f1cfa968c704"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c1d0e4ca-843d-4593-a6ff-661f89974b04"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ca758f7c-0517-491b-841a-85d49aa39c33"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ceaeefb0-f68b-4d24-aed0-a628120b11eb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d2f6ead2-02de-4952-af12-4e3ef69d4823"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d40a722d-ec6d-428f-b584-c7fa226d79a8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("db884ace-036e-40a1-9986-08fef43caaa5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ddd1520b-1e90-466b-91b2-a3b13e54402a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("df1140ca-80a4-4b92-a907-61e3ff382803"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e51617de-d9eb-4add-81bd-eda9a88aa21a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e6381095-eae1-4755-a9d8-d24715689b26"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e7e38be5-dd11-4617-9663-6ad8b0297c3e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e9d7157b-cb50-48d4-b487-c2295054cbd6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("edd07afe-26f2-486a-81bf-10dbfb2cacb2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ee807ac1-173b-4e51-b002-e2c9f1b6b30e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("eeba8f3f-2dc0-42a8-b03c-57fc41e51c42"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f3e450ca-1440-42e0-8ab7-6be64a0808d6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fd4392b3-4b0f-4486-b8d4-8da26278a018"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fe58f725-9870-4670-ba40-4e2ee085a866"));

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PlanLocations");

            migrationBuilder.DropColumn(
                name: "PayerId",
                table: "PlanLocations");

            migrationBuilder.CreateTable(
                name: "PlanLocationExpense",
                columns: table => new
                {
                    PlanLocationExpenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanLocationExpense", x => new { x.PlanLocationExpenseId, x.PlanLocationId });
                    table.ForeignKey(
                        name: "FK_PlanLocationExpense_PlanLocations_PlanLocationId",
                        column: x => x.PlanLocationId,
                        principalTable: "PlanLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("00a62c9d-3d68-484e-a0f3-95cf220764a1"), null, null, null, null, "Quảng Bình" },
                    { new Guid("0853974b-1dba-4135-a471-af1153f718a6"), null, null, null, null, "Cần Thơ" },
                    { new Guid("0885cf38-9947-4b60-b2b5-71e1f5ce8c97"), null, null, null, null, "Tây Ninh" },
                    { new Guid("0a430902-1ba5-43a0-ba11-63d6add6e94c"), null, null, null, null, "Hải Phòng" },
                    { new Guid("0c3cf51b-8ffb-4030-9667-e52c34b5cea1"), null, null, null, null, "Quảng Ngãi" },
                    { new Guid("131c347c-3cc7-42a7-a6f6-0e1990cb0b29"), null, null, null, null, "Hưng Yên" },
                    { new Guid("14be1b3c-784c-4576-aa59-0c9bc4d87da3"), null, null, null, null, "Ninh Thuận" },
                    { new Guid("26980a90-d6a5-4f83-be52-cb0d8ebceee9"), null, null, null, null, "Tuyên Quang" },
                    { new Guid("27063fc9-2f9f-4471-a52a-8f6a26c681bd"), null, null, null, null, "Bình Định" },
                    { new Guid("275c5756-ec6e-47be-b8fd-c861bd816a2b"), null, null, null, null, "Vĩnh Phúc" },
                    { new Guid("27fcfd70-230b-4a7b-8b7a-7cafad7d989e"), null, null, null, null, "Đồng Tháp" },
                    { new Guid("34e9002e-1abe-44e5-af99-cd2628fae946"), null, null, null, null, "Yên Bái" },
                    { new Guid("38fbe3c1-cbd3-4609-976e-ea2b14093776"), null, null, null, null, "Cà Mau" },
                    { new Guid("395f71ea-1025-459c-a54f-c7a00ca0bc7b"), null, null, null, null, "Lạng Sơn" },
                    { new Guid("3bcc8ff9-dad3-4001-ad08-4f90c58bc65d"), null, null, null, null, "Bắc Giang" },
                    { new Guid("40629ab7-57a5-4f0f-94bb-0caf600a8a08"), null, null, null, null, "Hà Tĩnh" },
                    { new Guid("4125d441-3341-4d77-baf3-e67b501614fc"), null, null, null, null, "Lào Cai" },
                    { new Guid("44b14cba-ce23-4b31-9ada-c929a1c2dcca"), null, null, null, null, "Quảng Trị" },
                    { new Guid("5033c219-a510-480b-b005-011b28e22752"), null, null, null, null, "Hà Nam" },
                    { new Guid("50e5043a-98f8-43bf-9a21-f1b6de57cbf4"), null, null, null, null, "Bình Thuận" },
                    { new Guid("52185e3e-78e9-48f4-9225-ac1cc86e9028"), null, null, null, null, "Nghệ An" },
                    { new Guid("560459a5-c6ce-4bed-816c-0a74988d5f9b"), null, null, null, null, "Đà Nẵng" },
                    { new Guid("5a0f0a14-63cd-4a28-8675-bc54776b6b85"), null, null, null, null, "Bà Rịa-Vũng Tàu" },
                    { new Guid("5be37a6f-bf19-4cb3-8a02-b3c8ccf6cce2"), null, null, null, null, "Thanh Hóa" },
                    { new Guid("5d3dd962-c726-4959-9fa5-7b57e6385452"), null, null, null, null, "Hòa Bình" },
                    { new Guid("62a0f69b-11be-475d-9e86-9e925bbd504f"), null, null, null, null, "Đắk Lắk" },
                    { new Guid("63d2f65d-0490-4979-a466-4d3e6788c8bb"), null, null, null, null, "Tiền Giang" },
                    { new Guid("643fad70-f81c-4c66-b44b-8adb08e451aa"), null, null, null, null, "Bạc Liêu" },
                    { new Guid("67220fbe-8aee-4692-a7d5-0df1e6e21d88"), null, null, null, null, "Bình Dương" },
                    { new Guid("67eeee4c-7f67-4ae8-904b-9a08f626a4ae"), null, null, null, null, "Sơn La" },
                    { new Guid("69134f6b-1717-4c3e-8f0f-20cacd30496a"), null, null, null, null, "Nam Định" },
                    { new Guid("6c070c17-3f77-48d4-971f-2225e5ce9463"), null, null, null, null, "Kiên Giang" },
                    { new Guid("6fbd1b73-34ad-46da-b950-f02d674fb313"), null, null, null, null, "Hà Nội" },
                    { new Guid("73e17935-a8d4-4859-9a31-cd1c2c253b35"), null, null, null, null, "Điện Biên" },
                    { new Guid("73fea91d-2763-4346-aca7-d7fc4df18444"), null, null, null, null, "Gia Lai" },
                    { new Guid("770ec7f2-3e32-4076-b06f-970133c74acf"), null, null, null, null, "Bến Tre" },
                    { new Guid("7e0de925-1825-4ad0-b064-bc69779882ed"), null, null, null, null, "Bắc Kạn" },
                    { new Guid("7ed755d7-8a43-4460-aaf1-19a1dd087d6f"), null, null, null, null, "Ninh Bình" },
                    { new Guid("7f55651d-a444-47d3-9eb4-631704f41f52"), null, null, null, null, "Hải Dương" },
                    { new Guid("87204733-61b1-4cef-ae7d-025d326709bf"), null, null, null, null, "Thừa Thiên - Huế" },
                    { new Guid("877d1f0e-32c4-42db-8bc7-6d571a774135"), null, null, null, null, "Sóc Trăng" },
                    { new Guid("8f5620fa-52a1-4df9-8676-bcbda4b9a9af"), null, null, null, null, "Thái Nguyên" },
                    { new Guid("9b2df20c-2604-4415-96fd-8abe29c2a133"), null, null, null, null, "TP. Hồ Chí Minh" },
                    { new Guid("9fdb7184-439d-4040-a262-dffc70000609"), null, null, null, null, "Cao Bằng" },
                    { new Guid("a21552ce-9dea-44bc-99c7-0ecdfd02f3a6"), null, null, null, null, "Khánh Hòa" },
                    { new Guid("b6f499fe-2455-44cd-abb8-f12bea9cc679"), null, null, null, null, "Lai Châu" },
                    { new Guid("baee76f2-8aef-43ff-9ee2-ac741f8cea4c"), null, null, null, null, "Phú Yên" },
                    { new Guid("c52af852-3c15-4820-9554-590647ede7bb"), null, null, null, null, "Quảng Ninh" },
                    { new Guid("ca0ce86b-2ba3-4beb-84d9-21e1b3d09896"), null, null, null, null, "Kon Tum" },
                    { new Guid("cc3a031e-6b27-4059-b2c6-1181e303bcf5"), null, null, null, null, "Bắc Ninh" },
                    { new Guid("d1e10f4a-f2dc-4d3e-90da-4c4d0fd80aac"), null, null, null, null, "An Giang" },
                    { new Guid("d3cc4ce4-61c3-4aca-8d7a-2c1cd86a3d11"), null, null, null, null, "Long An" },
                    { new Guid("d63b8b98-b98c-40ee-814a-20bd332da57a"), null, null, null, null, "Đắk Nông" },
                    { new Guid("d69cc249-a1c6-4610-b633-80f0abff82d7"), null, null, null, null, "Thái Bình" },
                    { new Guid("e127615d-f223-4bdc-a441-32df1e4bd6ec"), null, null, null, null, "Vĩnh Long" },
                    { new Guid("e69ab6aa-524f-4d70-8e9f-e82600c41e18"), null, null, null, null, "Phú Thọ" },
                    { new Guid("eb38f8fc-b257-4cfe-99cc-169b24db2c85"), null, null, null, null, "Lâm Đồng" },
                    { new Guid("ed6fb11f-17e8-45c7-b1f8-346de52a85aa"), null, null, null, null, "Hà Giang" },
                    { new Guid("f30d32fe-ced2-4e1f-a718-29fd49374427"), null, null, null, null, "Trà Vinh" },
                    { new Guid("f6eea8fa-2dcb-4cd5-b9a1-b59eba548a4b"), null, null, null, null, "Hậu Giang" },
                    { new Guid("f72efc61-55d3-4878-b48e-ae9ed6f54886"), null, null, null, null, "Quảng Nam" },
                    { new Guid("f9813d8c-6c90-4736-819e-c3f04d28e32e"), null, null, null, null, "Đồng Nai" },
                    { new Guid("fad174d7-b306-46fa-a54c-914e28fea1ba"), null, null, null, null, "Bình Phước" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanLocationExpense_PlanLocationId",
                table: "PlanLocationExpense",
                column: "PlanLocationId");
        }
    }
}
