using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelPlan.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabasePlanLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("023b6d60-bfed-4341-ae6d-d2be39936393"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0584f923-46c1-4d10-b31b-f029a7d02515"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("06c86f7e-920a-4870-ad2d-a411e55bff13"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("06dc0b6e-fdb7-45e9-abe1-3c9de0b1c4b4"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("103b7404-43c5-4425-9f37-6f0d1304cce0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2322126c-e5e2-4e55-ae80-2c5c75d6a630"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("232f47d0-13b3-4f56-ad48-f41216e7e841"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("27589e3a-5287-4902-843d-58c43aefc613"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2bbbe956-a75d-42e9-bdfa-db25f3fb3380"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2e5ce031-7bc8-404a-afd9-0ec731211304"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2e9ba341-ac8c-4901-b896-a74785b394cc"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2fdf1706-e2f2-41bf-97d9-4a74fbb1d9c2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("32808712-e8f6-415a-914b-ae31cc98ef5e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("335206b3-ccf1-4ce1-97aa-3bc12c286f43"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3c8a35e5-71ba-4503-8f5d-ad1902f37e69"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("41c1287d-e049-430c-9fab-34142a7dbe30"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4525dec2-9e41-42ec-8085-a173b3b78eb9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4914d92e-2407-46c0-a1ef-149016ad4379"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("49e1e6ee-9dfa-43c5-921a-fa5fd348d540"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("50b4de03-6c98-4470-9633-ea13c7438d1b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("517c62c0-43b9-42af-b5d2-dad067428c89"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("51c7b821-8b75-496c-8f12-b826575f65d3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("69e3feea-c93b-4c3e-ba00-9336f93a5a49"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("71487798-49a9-444b-ad7e-34acbae52526"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("74ebaf2b-536c-4877-bb17-85968d44dbe5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("76ddd145-73de-4303-bfb0-e131f21ca13c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("77ac3a25-6efc-49dd-b82a-cac70316fb60"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7a9b2108-a453-4386-9394-6d6894d97577"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7b8b184f-af5c-4ecf-8328-10bda331e872"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("84708191-afbf-423f-b694-8efe59ccb9f0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("87e80c31-c0a9-48a7-803e-ec2aea0e141a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("89ef0213-d57f-41dc-b6cc-bef4ee012478"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("927c29c6-fb8f-4548-9b71-0df0a6794363"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9511d2fa-e1be-4daa-b009-5e4e4d4e27f6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9b2e27f7-e813-4cb6-aeca-08197b89cdd8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a1d213e2-46d5-482e-87d2-72cbea2dec52"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a437e556-2af2-4619-a706-5e9795acb1b3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a4e984bc-dffd-4ec3-ad37-b66cce9b0063"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a54ebbb8-8792-42b5-9c55-7886fdb471c4"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a6eb3efd-e82e-4ff0-8a1d-7d7d3eb19c63"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a90cb483-2251-48d2-8737-45ce7162ae2d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b15b066e-ea59-41d5-8be4-f0dcf3828fee"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b4c5df8a-eb62-475c-a1c0-9749afd076e2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("bb385fa9-6608-40ad-894f-57ef83d888fb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("be879eef-7a11-4bd2-a9ca-1e741cd8f844"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c0ecaf21-e989-427d-8530-4eeb98f6c327"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c5016461-dc39-4473-9d24-00be5f7ba187"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("cb4bfbfd-61c1-4174-9209-64e07f9e702a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("cbd8da7a-4093-48cb-93da-eef88c107237"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("cd6f3c27-c2c7-49b7-9872-1736fd716f6c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("cdb2c932-1ca5-40c8-916c-f599c8948264"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ceb29c8b-315c-4ab3-b697-a95e2d04ea60"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d1a75184-c1d2-4ee9-8b98-6450e30bfc6f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d62eebf8-8f09-4d53-b032-60b5d2225ef2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d6433a86-0758-4c50-ab08-49b191e6fe4f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e2269799-f471-411b-ae01-d75ae4709edb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ebc6d613-f03c-4a11-a7bd-5e68d506c49a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ecba8a6a-990a-4e77-9c09-1c2e210bfe86"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ef494aa5-13ec-4950-8a12-da9d3b6f5b32"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f2802717-ba5f-415b-be01-3ca02e4f73cf"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f36cc496-dc5c-4a3b-8035-410730b390fb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f441f1a1-da09-4223-9bee-109c693738ac"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f7c5355a-0b15-4267-9d2d-4ca1428f358e"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "PlanLocations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "PlanLocations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "PlanLocations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "PlanLocations");

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("023b6d60-bfed-4341-ae6d-d2be39936393"), null, null, null, null, "Bình Phước" },
                    { new Guid("0584f923-46c1-4d10-b31b-f029a7d02515"), null, null, null, null, "Tây Ninh" },
                    { new Guid("06c86f7e-920a-4870-ad2d-a411e55bff13"), null, null, null, null, "Bình Thuận" },
                    { new Guid("06dc0b6e-fdb7-45e9-abe1-3c9de0b1c4b4"), null, null, null, null, "Bến Tre" },
                    { new Guid("103b7404-43c5-4425-9f37-6f0d1304cce0"), null, null, null, null, "Tiền Giang" },
                    { new Guid("2322126c-e5e2-4e55-ae80-2c5c75d6a630"), null, null, null, null, "Bạc Liêu" },
                    { new Guid("232f47d0-13b3-4f56-ad48-f41216e7e841"), null, null, null, null, "Cà Mau" },
                    { new Guid("27589e3a-5287-4902-843d-58c43aefc613"), null, null, null, null, "Hòa Bình" },
                    { new Guid("2bbbe956-a75d-42e9-bdfa-db25f3fb3380"), null, null, null, null, "Đồng Nai" },
                    { new Guid("2e5ce031-7bc8-404a-afd9-0ec731211304"), null, null, null, null, "Nghệ An" },
                    { new Guid("2e9ba341-ac8c-4901-b896-a74785b394cc"), null, null, null, null, "Bắc Giang" },
                    { new Guid("2fdf1706-e2f2-41bf-97d9-4a74fbb1d9c2"), null, null, null, null, "Đà Nẵng" },
                    { new Guid("32808712-e8f6-415a-914b-ae31cc98ef5e"), null, null, null, null, "Long An" },
                    { new Guid("335206b3-ccf1-4ce1-97aa-3bc12c286f43"), null, null, null, null, "Hậu Giang" },
                    { new Guid("3c8a35e5-71ba-4503-8f5d-ad1902f37e69"), null, null, null, null, "Lạng Sơn" },
                    { new Guid("41c1287d-e049-430c-9fab-34142a7dbe30"), null, null, null, null, "Lâm Đồng" },
                    { new Guid("4525dec2-9e41-42ec-8085-a173b3b78eb9"), null, null, null, null, "An Giang" },
                    { new Guid("4914d92e-2407-46c0-a1ef-149016ad4379"), null, null, null, null, "Quảng Bình" },
                    { new Guid("49e1e6ee-9dfa-43c5-921a-fa5fd348d540"), null, null, null, null, "Tuyên Quang" },
                    { new Guid("50b4de03-6c98-4470-9633-ea13c7438d1b"), null, null, null, null, "Sóc Trăng" },
                    { new Guid("517c62c0-43b9-42af-b5d2-dad067428c89"), null, null, null, null, "Khánh Hòa" },
                    { new Guid("51c7b821-8b75-496c-8f12-b826575f65d3"), null, null, null, null, "Quảng Trị" },
                    { new Guid("69e3feea-c93b-4c3e-ba00-9336f93a5a49"), null, null, null, null, "Cần Thơ" },
                    { new Guid("71487798-49a9-444b-ad7e-34acbae52526"), null, null, null, null, "Ninh Thuận" },
                    { new Guid("74ebaf2b-536c-4877-bb17-85968d44dbe5"), null, null, null, null, "Gia Lai" },
                    { new Guid("76ddd145-73de-4303-bfb0-e131f21ca13c"), null, null, null, null, "TP. Hồ Chí Minh" },
                    { new Guid("77ac3a25-6efc-49dd-b82a-cac70316fb60"), null, null, null, null, "Thừa Thiên - Huế" },
                    { new Guid("7a9b2108-a453-4386-9394-6d6894d97577"), null, null, null, null, "Hà Nội" },
                    { new Guid("7b8b184f-af5c-4ecf-8328-10bda331e872"), null, null, null, null, "Thanh Hóa" },
                    { new Guid("84708191-afbf-423f-b694-8efe59ccb9f0"), null, null, null, null, "Cao Bằng" },
                    { new Guid("87e80c31-c0a9-48a7-803e-ec2aea0e141a"), null, null, null, null, "Điện Biên" },
                    { new Guid("89ef0213-d57f-41dc-b6cc-bef4ee012478"), null, null, null, null, "Sơn La" },
                    { new Guid("927c29c6-fb8f-4548-9b71-0df0a6794363"), null, null, null, null, "Bắc Ninh" },
                    { new Guid("9511d2fa-e1be-4daa-b009-5e4e4d4e27f6"), null, null, null, null, "Yên Bái" },
                    { new Guid("9b2e27f7-e813-4cb6-aeca-08197b89cdd8"), null, null, null, null, "Lào Cai" },
                    { new Guid("a1d213e2-46d5-482e-87d2-72cbea2dec52"), null, null, null, null, "Hưng Yên" },
                    { new Guid("a437e556-2af2-4619-a706-5e9795acb1b3"), null, null, null, null, "Bắc Kạn" },
                    { new Guid("a4e984bc-dffd-4ec3-ad37-b66cce9b0063"), null, null, null, null, "Đắk Lắk" },
                    { new Guid("a54ebbb8-8792-42b5-9c55-7886fdb471c4"), null, null, null, null, "Kon Tum" },
                    { new Guid("a6eb3efd-e82e-4ff0-8a1d-7d7d3eb19c63"), null, null, null, null, "Hà Tĩnh" },
                    { new Guid("a90cb483-2251-48d2-8737-45ce7162ae2d"), null, null, null, null, "Quảng Nam" },
                    { new Guid("b15b066e-ea59-41d5-8be4-f0dcf3828fee"), null, null, null, null, "Trà Vinh" },
                    { new Guid("b4c5df8a-eb62-475c-a1c0-9749afd076e2"), null, null, null, null, "Phú Thọ" },
                    { new Guid("bb385fa9-6608-40ad-894f-57ef83d888fb"), null, null, null, null, "Hà Nam" },
                    { new Guid("be879eef-7a11-4bd2-a9ca-1e741cd8f844"), null, null, null, null, "Phú Yên" },
                    { new Guid("c0ecaf21-e989-427d-8530-4eeb98f6c327"), null, null, null, null, "Hải Phòng" },
                    { new Guid("c5016461-dc39-4473-9d24-00be5f7ba187"), null, null, null, null, "Đồng Tháp" },
                    { new Guid("cb4bfbfd-61c1-4174-9209-64e07f9e702a"), null, null, null, null, "Thái Nguyên" },
                    { new Guid("cbd8da7a-4093-48cb-93da-eef88c107237"), null, null, null, null, "Bình Dương" },
                    { new Guid("cd6f3c27-c2c7-49b7-9872-1736fd716f6c"), null, null, null, null, "Vĩnh Phúc" },
                    { new Guid("cdb2c932-1ca5-40c8-916c-f599c8948264"), null, null, null, null, "Thái Bình" },
                    { new Guid("ceb29c8b-315c-4ab3-b697-a95e2d04ea60"), null, null, null, null, "Kiên Giang" },
                    { new Guid("d1a75184-c1d2-4ee9-8b98-6450e30bfc6f"), null, null, null, null, "Vĩnh Long" },
                    { new Guid("d62eebf8-8f09-4d53-b032-60b5d2225ef2"), null, null, null, null, "Bà Rịa-Vũng Tàu" },
                    { new Guid("d6433a86-0758-4c50-ab08-49b191e6fe4f"), null, null, null, null, "Quảng Ngãi" },
                    { new Guid("e2269799-f471-411b-ae01-d75ae4709edb"), null, null, null, null, "Lai Châu" },
                    { new Guid("ebc6d613-f03c-4a11-a7bd-5e68d506c49a"), null, null, null, null, "Ninh Bình" },
                    { new Guid("ecba8a6a-990a-4e77-9c09-1c2e210bfe86"), null, null, null, null, "Quảng Ninh" },
                    { new Guid("ef494aa5-13ec-4950-8a12-da9d3b6f5b32"), null, null, null, null, "Hải Dương" },
                    { new Guid("f2802717-ba5f-415b-be01-3ca02e4f73cf"), null, null, null, null, "Bình Định" },
                    { new Guid("f36cc496-dc5c-4a3b-8035-410730b390fb"), null, null, null, null, "Đắk Nông" },
                    { new Guid("f441f1a1-da09-4223-9bee-109c693738ac"), null, null, null, null, "Nam Định" },
                    { new Guid("f7c5355a-0b15-4267-9d2d-4ca1428f358e"), null, null, null, null, "Hà Giang" }
                });
        }
    }
}
