using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelPlan.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initdataprovince : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("0240a6f0-41b3-48e6-8329-330b0da8ec5d"), null, null, null, null, "Kiên Giang" },
                    { new Guid("0a4985fa-f4dc-4e3a-9a36-8bd7bec7036c"), null, null, null, null, "Đắk Nông" },
                    { new Guid("0bb13b94-9b70-4f78-bc7b-70d5a7c37dcf"), null, null, null, null, "Điện Biên" },
                    { new Guid("0be9dfa7-e19c-4dd3-8ae2-d134d8800ec9"), null, null, null, null, "Nghệ An" },
                    { new Guid("0f6c60e0-6ee6-4982-97d3-b65f7a9429b9"), null, null, null, null, "Thái Nguyên" },
                    { new Guid("0f9c56d5-4778-475f-bc98-90c5f614a941"), null, null, null, null, "Tiền Giang" },
                    { new Guid("106e29fe-6f1e-4357-b6b7-fae7a07b0cc7"), null, null, null, null, "Ninh Bình" },
                    { new Guid("13cee0ac-aec3-4449-afef-eb9881743d15"), null, null, null, null, "Long An" },
                    { new Guid("1868703f-7c20-42b6-93ce-67b59ab95afd"), null, null, null, null, "Hà Giang" },
                    { new Guid("1bd0e869-2569-4e01-b81e-1808236ff92c"), null, null, null, null, "Yên Bái" },
                    { new Guid("1fd35b1d-719b-45e8-868d-cfd50db49554"), null, null, null, null, "Phú Yên" },
                    { new Guid("2534c856-0afa-4c15-8e28-951418b77509"), null, null, null, null, "Hà Nam" },
                    { new Guid("255f6085-ff1f-4cd8-b074-8066a440c28b"), null, null, null, null, "Bến Tre" },
                    { new Guid("2f79089c-bb98-4ba0-80df-e73e56595507"), null, null, null, null, "Vĩnh Phúc" },
                    { new Guid("3305760c-f72d-4926-83e5-5ee0d04bf8c6"), null, null, null, null, "Thừa Thiên - Huế" },
                    { new Guid("33977811-8d62-4c1a-ae48-cca61fc8b8e6"), null, null, null, null, "Quảng Ngãi" },
                    { new Guid("38a1f7e8-0c1a-4f26-afba-492a2543c5b8"), null, null, null, null, "Bình Dương" },
                    { new Guid("41019a0f-8109-4340-8117-1046a61e8968"), null, null, null, null, "Phú Thọ" },
                    { new Guid("41ee2ee8-1819-4876-a9b6-5d24ab401870"), null, null, null, null, "Hà Tĩnh" },
                    { new Guid("469d51e8-8962-4684-9aa4-1155b03a0f00"), null, null, null, null, "An Giang" },
                    { new Guid("4b531bf0-efe5-4f70-8f13-0b136a01b750"), null, null, null, null, "Đồng Tháp" },
                    { new Guid("4fee88a7-ba05-47a4-81d3-0da99e92b04a"), null, null, null, null, "Đà Nẵng" },
                    { new Guid("53e495ab-4a60-497a-a93f-88fc755ec7c5"), null, null, null, null, "Lạng Sơn" },
                    { new Guid("55080d85-c728-4053-b6ec-ba6eff901417"), null, null, null, null, "Lâm Đồng" },
                    { new Guid("57a47d44-9eb2-4d0e-978e-00233b3b6bc6"), null, null, null, null, "Bắc Ninh" },
                    { new Guid("585928da-e3d3-4f3a-ae84-07dc9c5c8ee3"), null, null, null, null, "Bạc Liêu" },
                    { new Guid("674e216b-462f-4faa-babd-d2a7a7898cae"), null, null, null, null, "Nam Định" },
                    { new Guid("69dadd78-83e8-4db9-be97-7abed515bb7a"), null, null, null, null, "Tuyên Quang" },
                    { new Guid("705493ad-2f3f-4e1f-a7f4-b6edf1bc45db"), null, null, null, null, "Quảng Trị" },
                    { new Guid("75fc3afa-fcd1-4d5a-af72-6a0f18cb9356"), null, null, null, null, "Đắk Lắk" },
                    { new Guid("771774f3-de20-4849-b905-80a3482628ca"), null, null, null, null, "Khánh Hòa" },
                    { new Guid("7b41d512-dad4-46ef-989e-8f43445a73e6"), null, null, null, null, "Bình Phước" },
                    { new Guid("7e3a4c8c-0382-42eb-b158-dd4c2a7efd04"), null, null, null, null, "Thanh Hóa" },
                    { new Guid("840db29d-c732-4b82-a6ec-72ab13aeb103"), null, null, null, null, "Cà Mau" },
                    { new Guid("8b365a56-c2e4-4061-98be-0521d3ea918d"), null, null, null, null, "Thái Bình" },
                    { new Guid("931661ce-783e-41be-9b8e-685c57861216"), null, null, null, null, "Trà Vinh" },
                    { new Guid("9a6c53e9-ba9f-45b6-b6a1-a2eb863ba89d"), null, null, null, null, "Hòa Bình" },
                    { new Guid("9e335a54-3f37-41e0-b698-503337f1825b"), null, null, null, null, "Hải Phòng" },
                    { new Guid("a5f509f4-52ee-487f-a647-facd36b7b155"), null, null, null, null, "Bắc Giang" },
                    { new Guid("a651949b-ecbd-4984-9959-bbaa590a29d2"), null, null, null, null, "Tây Ninh" },
                    { new Guid("a6e5d286-e7bb-4cc8-9942-683499a69389"), null, null, null, null, "Cần Thơ" },
                    { new Guid("a742b818-97b3-4eac-b0bd-5a5f6fae29eb"), null, null, null, null, "Ninh Thuận" },
                    { new Guid("b0cc04c8-00a4-4356-a075-a955a76efa83"), null, null, null, null, "Hậu Giang" },
                    { new Guid("b4e1537f-a0eb-4df0-9642-9c1456d7c2e9"), null, null, null, null, "Bình Định" },
                    { new Guid("b6994a44-4ceb-4235-9072-f3cef8e6ff1d"), null, null, null, null, "Sóc Trăng" },
                    { new Guid("bc2d77bd-222f-4c47-b63f-a5c9c8e5eca3"), null, null, null, null, "Quảng Bình" },
                    { new Guid("c054cd3b-cc8b-4de9-82a5-945f6189d00d"), null, null, null, null, "Gia Lai" },
                    { new Guid("c95036a6-cb05-40dd-b795-f2848beba466"), null, null, null, null, "Lai Châu" },
                    { new Guid("cb2dfde5-67bd-46b9-87fc-aeb667c0b989"), null, null, null, null, "Vĩnh Long" },
                    { new Guid("d0d4f625-4371-4689-b35e-4edd81433df7"), null, null, null, null, "Đồng Nai" },
                    { new Guid("d2f4b2ed-d339-4595-8215-17be04839a14"), null, null, null, null, "Kon Tum" },
                    { new Guid("d59edfa2-268c-44b8-a060-967f94873bb1"), null, null, null, null, "Bà Rịa-Vũng Tàu" },
                    { new Guid("d6760ae7-be27-4f3b-a609-d4b55cfbeede"), null, null, null, null, "Cao Bằng" },
                    { new Guid("d9da5b2c-14a2-4e2c-ac2e-ccab8c5a2c2e"), null, null, null, null, "Quảng Ninh" },
                    { new Guid("dcacf024-0d9c-42ff-ac92-499c77cae93b"), null, null, null, null, "Hưng Yên" },
                    { new Guid("e9a7dc99-b998-4e6d-a573-5a6faf65f952"), null, null, null, null, "Bình Thuận" },
                    { new Guid("ea25cccf-c07e-4534-8708-893aa2ab8067"), null, null, null, null, "Hà Nội" },
                    { new Guid("f2ec6566-a290-4f4e-bc5f-5556e2833b9f"), null, null, null, null, "TP. Hồ Chí Minh" },
                    { new Guid("f42dce30-f80c-40fd-89d3-242d6ab413f9"), null, null, null, null, "Quảng Nam" },
                    { new Guid("f88bae71-0f08-4cd7-8400-1660c2291e4d"), null, null, null, null, "Lào Cai" },
                    { new Guid("f9dd5bf5-f8c6-48a7-ac2d-6463107f5300"), null, null, null, null, "Hải Dương" },
                    { new Guid("faf91b46-ae81-4270-98f7-e4b2662773df"), null, null, null, null, "Bắc Kạn" },
                    { new Guid("fc467819-7139-4bc4-854f-222395bd3805"), null, null, null, null, "Sơn La" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0240a6f0-41b3-48e6-8329-330b0da8ec5d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0a4985fa-f4dc-4e3a-9a36-8bd7bec7036c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0bb13b94-9b70-4f78-bc7b-70d5a7c37dcf"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0be9dfa7-e19c-4dd3-8ae2-d134d8800ec9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0f6c60e0-6ee6-4982-97d3-b65f7a9429b9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0f9c56d5-4778-475f-bc98-90c5f614a941"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("106e29fe-6f1e-4357-b6b7-fae7a07b0cc7"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("13cee0ac-aec3-4449-afef-eb9881743d15"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1868703f-7c20-42b6-93ce-67b59ab95afd"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1bd0e869-2569-4e01-b81e-1808236ff92c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1fd35b1d-719b-45e8-868d-cfd50db49554"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2534c856-0afa-4c15-8e28-951418b77509"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("255f6085-ff1f-4cd8-b074-8066a440c28b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2f79089c-bb98-4ba0-80df-e73e56595507"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3305760c-f72d-4926-83e5-5ee0d04bf8c6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("33977811-8d62-4c1a-ae48-cca61fc8b8e6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("38a1f7e8-0c1a-4f26-afba-492a2543c5b8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("41019a0f-8109-4340-8117-1046a61e8968"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("41ee2ee8-1819-4876-a9b6-5d24ab401870"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("469d51e8-8962-4684-9aa4-1155b03a0f00"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4b531bf0-efe5-4f70-8f13-0b136a01b750"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4fee88a7-ba05-47a4-81d3-0da99e92b04a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("53e495ab-4a60-497a-a93f-88fc755ec7c5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("55080d85-c728-4053-b6ec-ba6eff901417"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("57a47d44-9eb2-4d0e-978e-00233b3b6bc6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("585928da-e3d3-4f3a-ae84-07dc9c5c8ee3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("674e216b-462f-4faa-babd-d2a7a7898cae"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("69dadd78-83e8-4db9-be97-7abed515bb7a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("705493ad-2f3f-4e1f-a7f4-b6edf1bc45db"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("75fc3afa-fcd1-4d5a-af72-6a0f18cb9356"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("771774f3-de20-4849-b905-80a3482628ca"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7b41d512-dad4-46ef-989e-8f43445a73e6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7e3a4c8c-0382-42eb-b158-dd4c2a7efd04"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("840db29d-c732-4b82-a6ec-72ab13aeb103"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8b365a56-c2e4-4061-98be-0521d3ea918d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("931661ce-783e-41be-9b8e-685c57861216"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9a6c53e9-ba9f-45b6-b6a1-a2eb863ba89d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9e335a54-3f37-41e0-b698-503337f1825b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a5f509f4-52ee-487f-a647-facd36b7b155"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a651949b-ecbd-4984-9959-bbaa590a29d2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a6e5d286-e7bb-4cc8-9942-683499a69389"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a742b818-97b3-4eac-b0bd-5a5f6fae29eb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b0cc04c8-00a4-4356-a075-a955a76efa83"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b4e1537f-a0eb-4df0-9642-9c1456d7c2e9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b6994a44-4ceb-4235-9072-f3cef8e6ff1d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("bc2d77bd-222f-4c47-b63f-a5c9c8e5eca3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c054cd3b-cc8b-4de9-82a5-945f6189d00d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c95036a6-cb05-40dd-b795-f2848beba466"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("cb2dfde5-67bd-46b9-87fc-aeb667c0b989"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d0d4f625-4371-4689-b35e-4edd81433df7"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d2f4b2ed-d339-4595-8215-17be04839a14"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d59edfa2-268c-44b8-a060-967f94873bb1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d6760ae7-be27-4f3b-a609-d4b55cfbeede"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d9da5b2c-14a2-4e2c-ac2e-ccab8c5a2c2e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("dcacf024-0d9c-42ff-ac92-499c77cae93b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e9a7dc99-b998-4e6d-a573-5a6faf65f952"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ea25cccf-c07e-4534-8708-893aa2ab8067"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f2ec6566-a290-4f4e-bc5f-5556e2833b9f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f42dce30-f80c-40fd-89d3-242d6ab413f9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f88bae71-0f08-4cd7-8400-1660c2291e4d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f9dd5bf5-f8c6-48a7-ac2d-6463107f5300"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("faf91b46-ae81-4270-98f7-e4b2662773df"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fc467819-7139-4bc4-854f-222395bd3805"));
        }
    }
}
