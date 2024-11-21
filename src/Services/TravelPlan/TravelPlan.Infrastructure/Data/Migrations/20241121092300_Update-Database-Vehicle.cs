using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelPlan.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanVehicle");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("016c488f-7bc3-4886-92fa-c8c0354cabb3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("07874301-f019-492b-9df4-147cf889f582"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("097ef89a-83d8-4206-a498-45b91fdcc378"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0af64983-3244-400f-a9e9-d6f499ef452f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0f38548b-5232-4de8-aa07-9c4409ce1bc8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("10dc4f00-3631-4cb3-bc50-05dc13de7f49"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("13d46866-d502-4a6c-bc8f-7940ffc2f2ed"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("155c7389-5bcd-463b-81a7-acbd6e212be2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1a13b507-efa6-4113-9f19-670f29d4d931"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1c55613d-58a1-443d-83de-e69ef4e13def"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("312a3b80-657f-4093-890a-9d797f838dcd"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("336d4327-f1e8-47c3-9116-07cc0cb6fbfb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("34f202fb-26d5-4103-91ca-16b30c2b04c9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("39c2511d-b6d0-40ec-a2ac-3155d515b166"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3f69babb-53a4-4923-a70b-11bee8c4fda8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("404e57a3-090d-4772-b313-a1ffbe1ccd33"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("495f0339-5fe5-4b3a-b654-132a737ce45b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("58067018-5f7d-465c-a4fd-a12e7983ca84"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5a0fe6c6-61ac-4274-a52f-7c515d22380e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("61cc9727-d605-45bd-a742-09dc80eb04ea"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("644e8b63-7acb-404b-a28b-52cbce6dc51b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("673a9f95-1f9a-4e7d-beda-c2725f3f68dc"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6c0101e6-3124-4139-b329-d965bf1951c2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6d2053c0-8d2c-4db7-b8d6-b1d434bf1910"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6ed9a82f-b18a-46cd-938c-fbc71b5966f9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("70079235-c647-49e4-b0bb-a7979f826a89"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("705accf1-47ee-4893-9610-ce1410e672fb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("70d48577-9c2e-45e8-bc18-ab98eb8e95d0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("70f25dcb-25ae-4e92-af7c-a8abb01fc820"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7125a3b2-dc31-42b2-bd5d-8f39ee3f823a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("71fd1da7-4e30-4d88-b6a4-5a101195411c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7d41a692-1bde-4cb0-949e-d2f1746447f8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7e3fd972-e3d9-46f5-8344-bf9978d8d90f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("87085a24-469a-4dd5-b541-5fbce8905208"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("88291cc8-db60-4073-9b46-1348afdaf15c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("89186d5f-1509-4cb8-8759-2fdeed0773da"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8d3bf99d-029e-4f08-b531-c6db65eac304"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8e11eaf7-e535-4cb8-953c-2d049ccb4174"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8ee9113e-e87c-4e53-883a-48cc8bb72904"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("93f17f3c-8c79-4125-800d-0968f66b51d6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9411043c-bfab-4127-8d51-262288fbdafb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("988e3b42-96ac-428c-bdf8-db0d9a1241f8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a297a3d4-ad61-4020-b31e-75835edc1418"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a36dddfc-bb29-4c7c-8148-e162d733a0db"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a808525c-c24a-42c9-bdd8-6c4e95596d56"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a951a190-ed2f-44e6-b7d4-e3977fab6b5a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ab1e3def-0b30-400c-a689-5dfb8ebc551b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ad111df5-d20b-4be4-bff2-46285fc899ee"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b2dee183-872c-42b9-9d93-2e8b2a124481"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("bb3271aa-d2c5-4e98-9716-5a627fe819e1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("bf1f8e6d-fce1-41c3-ae2c-a0fb3cdb288f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c029f3ba-b0a7-4c6c-9cf2-25a3808c6c49"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c16b3363-329e-446c-9715-b00b6508973b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("cd2030db-f429-4b6e-b828-037beab8739d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("df5a5900-c5ab-47c5-9fb9-242a1aadc418"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e143e3e8-e45a-4c5c-8e29-b36c580bf58e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e5b223b5-0039-4d3c-96b3-7a7cd9867548"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e8d7cbd7-0437-4476-9b67-57fea056daaa"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ea5134e9-371a-4770-98f2-8c60c9c5a544"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ef9edb29-df85-472e-b601-6978532be853"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f4f091d4-fc4d-4800-b108-b4823de2ccd3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fa25ed5c-54a9-455a-b90f-864bcd3267ed"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fa648e13-4134-4fd9-9f27-0a78d9175a69"));

            migrationBuilder.AddColumn<string>(
                name: "Vehicle",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Vehicle",
                table: "Plans");

            migrationBuilder.CreateTable(
                name: "PlanVehicle",
                columns: table => new
                {
                    PlanVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vehicle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanVehicle", x => new { x.PlanVehicleId, x.PlanId });
                    table.ForeignKey(
                        name: "FK_PlanVehicle_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("016c488f-7bc3-4886-92fa-c8c0354cabb3"), null, null, null, null, "Đà Nẵng" },
                    { new Guid("07874301-f019-492b-9df4-147cf889f582"), null, null, null, null, "Quảng Ninh" },
                    { new Guid("097ef89a-83d8-4206-a498-45b91fdcc378"), null, null, null, null, "Tuyên Quang" },
                    { new Guid("0af64983-3244-400f-a9e9-d6f499ef452f"), null, null, null, null, "Sóc Trăng" },
                    { new Guid("0f38548b-5232-4de8-aa07-9c4409ce1bc8"), null, null, null, null, "Cà Mau" },
                    { new Guid("10dc4f00-3631-4cb3-bc50-05dc13de7f49"), null, null, null, null, "Cao Bằng" },
                    { new Guid("13d46866-d502-4a6c-bc8f-7940ffc2f2ed"), null, null, null, null, "Bắc Giang" },
                    { new Guid("155c7389-5bcd-463b-81a7-acbd6e212be2"), null, null, null, null, "Tây Ninh" },
                    { new Guid("1a13b507-efa6-4113-9f19-670f29d4d931"), null, null, null, null, "Thanh Hóa" },
                    { new Guid("1c55613d-58a1-443d-83de-e69ef4e13def"), null, null, null, null, "Hải Dương" },
                    { new Guid("312a3b80-657f-4093-890a-9d797f838dcd"), null, null, null, null, "Thừa Thiên - Huế" },
                    { new Guid("336d4327-f1e8-47c3-9116-07cc0cb6fbfb"), null, null, null, null, "Ninh Thuận" },
                    { new Guid("34f202fb-26d5-4103-91ca-16b30c2b04c9"), null, null, null, null, "Nghệ An" },
                    { new Guid("39c2511d-b6d0-40ec-a2ac-3155d515b166"), null, null, null, null, "Bạc Liêu" },
                    { new Guid("3f69babb-53a4-4923-a70b-11bee8c4fda8"), null, null, null, null, "Điện Biên" },
                    { new Guid("404e57a3-090d-4772-b313-a1ffbe1ccd33"), null, null, null, null, "TP. Hồ Chí Minh" },
                    { new Guid("495f0339-5fe5-4b3a-b654-132a737ce45b"), null, null, null, null, "Hòa Bình" },
                    { new Guid("58067018-5f7d-465c-a4fd-a12e7983ca84"), null, null, null, null, "Hậu Giang" },
                    { new Guid("5a0fe6c6-61ac-4274-a52f-7c515d22380e"), null, null, null, null, "Cần Thơ" },
                    { new Guid("61cc9727-d605-45bd-a742-09dc80eb04ea"), null, null, null, null, "Thái Nguyên" },
                    { new Guid("644e8b63-7acb-404b-a28b-52cbce6dc51b"), null, null, null, null, "Kon Tum" },
                    { new Guid("673a9f95-1f9a-4e7d-beda-c2725f3f68dc"), null, null, null, null, "Phú Yên" },
                    { new Guid("6c0101e6-3124-4139-b329-d965bf1951c2"), null, null, null, null, "Kiên Giang" },
                    { new Guid("6d2053c0-8d2c-4db7-b8d6-b1d434bf1910"), null, null, null, null, "Bà Rịa-Vũng Tàu" },
                    { new Guid("6ed9a82f-b18a-46cd-938c-fbc71b5966f9"), null, null, null, null, "Đồng Tháp" },
                    { new Guid("70079235-c647-49e4-b0bb-a7979f826a89"), null, null, null, null, "Phú Thọ" },
                    { new Guid("705accf1-47ee-4893-9610-ce1410e672fb"), null, null, null, null, "Quảng Nam" },
                    { new Guid("70d48577-9c2e-45e8-bc18-ab98eb8e95d0"), null, null, null, null, "Trà Vinh" },
                    { new Guid("70f25dcb-25ae-4e92-af7c-a8abb01fc820"), null, null, null, null, "Bắc Kạn" },
                    { new Guid("7125a3b2-dc31-42b2-bd5d-8f39ee3f823a"), null, null, null, null, "Vĩnh Long" },
                    { new Guid("71fd1da7-4e30-4d88-b6a4-5a101195411c"), null, null, null, null, "Ninh Bình" },
                    { new Guid("7d41a692-1bde-4cb0-949e-d2f1746447f8"), null, null, null, null, "Yên Bái" },
                    { new Guid("7e3fd972-e3d9-46f5-8344-bf9978d8d90f"), null, null, null, null, "Nam Định" },
                    { new Guid("87085a24-469a-4dd5-b541-5fbce8905208"), null, null, null, null, "Hà Nội" },
                    { new Guid("88291cc8-db60-4073-9b46-1348afdaf15c"), null, null, null, null, "Bình Định" },
                    { new Guid("89186d5f-1509-4cb8-8759-2fdeed0773da"), null, null, null, null, "Đắk Lắk" },
                    { new Guid("8d3bf99d-029e-4f08-b531-c6db65eac304"), null, null, null, null, "Bình Phước" },
                    { new Guid("8e11eaf7-e535-4cb8-953c-2d049ccb4174"), null, null, null, null, "Lâm Đồng" },
                    { new Guid("8ee9113e-e87c-4e53-883a-48cc8bb72904"), null, null, null, null, "Quảng Trị" },
                    { new Guid("93f17f3c-8c79-4125-800d-0968f66b51d6"), null, null, null, null, "Tiền Giang" },
                    { new Guid("9411043c-bfab-4127-8d51-262288fbdafb"), null, null, null, null, "Bình Thuận" },
                    { new Guid("988e3b42-96ac-428c-bdf8-db0d9a1241f8"), null, null, null, null, "Hà Giang" },
                    { new Guid("a297a3d4-ad61-4020-b31e-75835edc1418"), null, null, null, null, "Đồng Nai" },
                    { new Guid("a36dddfc-bb29-4c7c-8148-e162d733a0db"), null, null, null, null, "Lào Cai" },
                    { new Guid("a808525c-c24a-42c9-bdd8-6c4e95596d56"), null, null, null, null, "Quảng Bình" },
                    { new Guid("a951a190-ed2f-44e6-b7d4-e3977fab6b5a"), null, null, null, null, "Hưng Yên" },
                    { new Guid("ab1e3def-0b30-400c-a689-5dfb8ebc551b"), null, null, null, null, "Gia Lai" },
                    { new Guid("ad111df5-d20b-4be4-bff2-46285fc899ee"), null, null, null, null, "Hải Phòng" },
                    { new Guid("b2dee183-872c-42b9-9d93-2e8b2a124481"), null, null, null, null, "Đắk Nông" },
                    { new Guid("bb3271aa-d2c5-4e98-9716-5a627fe819e1"), null, null, null, null, "Sơn La" },
                    { new Guid("bf1f8e6d-fce1-41c3-ae2c-a0fb3cdb288f"), null, null, null, null, "Hà Tĩnh" },
                    { new Guid("c029f3ba-b0a7-4c6c-9cf2-25a3808c6c49"), null, null, null, null, "Khánh Hòa" },
                    { new Guid("c16b3363-329e-446c-9715-b00b6508973b"), null, null, null, null, "Bến Tre" },
                    { new Guid("cd2030db-f429-4b6e-b828-037beab8739d"), null, null, null, null, "Lai Châu" },
                    { new Guid("df5a5900-c5ab-47c5-9fb9-242a1aadc418"), null, null, null, null, "Bắc Ninh" },
                    { new Guid("e143e3e8-e45a-4c5c-8e29-b36c580bf58e"), null, null, null, null, "An Giang" },
                    { new Guid("e5b223b5-0039-4d3c-96b3-7a7cd9867548"), null, null, null, null, "Vĩnh Phúc" },
                    { new Guid("e8d7cbd7-0437-4476-9b67-57fea056daaa"), null, null, null, null, "Long An" },
                    { new Guid("ea5134e9-371a-4770-98f2-8c60c9c5a544"), null, null, null, null, "Quảng Ngãi" },
                    { new Guid("ef9edb29-df85-472e-b601-6978532be853"), null, null, null, null, "Thái Bình" },
                    { new Guid("f4f091d4-fc4d-4800-b108-b4823de2ccd3"), null, null, null, null, "Lạng Sơn" },
                    { new Guid("fa25ed5c-54a9-455a-b90f-864bcd3267ed"), null, null, null, null, "Bình Dương" },
                    { new Guid("fa648e13-4134-4fd9-9f27-0a78d9175a69"), null, null, null, null, "Hà Nam" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanVehicle_PlanId",
                table: "PlanVehicle",
                column: "PlanId");
        }
    }
}
