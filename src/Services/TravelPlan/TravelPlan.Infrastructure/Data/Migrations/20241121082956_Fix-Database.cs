using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelPlan.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0286f3ad-812c-4512-9546-26086086f814"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("02b47fe6-5c30-42b2-bb2c-04f0fca94832"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("04c5e68f-bbc3-47c8-900a-d9c775480265"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("059358f1-704f-4644-bdd2-c45ce4781417"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("08b14fe5-5838-4897-a929-612bd662775e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("12e7c647-e56e-4ff2-be33-9b3c7995fb66"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("18a454ff-baa3-480c-a251-5e877bb3327a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1900963f-bf8e-487a-b23d-ec2f07c39a41"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1e04319a-6cb3-4b01-8bdb-143d189372ab"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("217b0e37-5c4b-4315-a9d2-534a3f0bc974"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("25a1d71b-d0ea-4fe5-b395-598880f310b9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("283d74cc-abfa-4b18-8d25-4ac8299331e0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("28ef865d-0c27-4600-9030-36339b6921a6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("31e662cf-7c2e-4477-acac-21bb625481f1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("339a55cd-a94a-436d-907b-41e607d472a2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("348f328a-727e-45ca-b645-4f0a0877bb83"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("35bfd1b1-6fa9-436e-9787-0a844bf9ea96"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("35d44b36-41dc-4b4a-989f-6dfeb21ce519"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("39761c2a-2b98-429b-8522-3cc75cc64caf"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3dc46f6c-9396-45c0-876a-d1f6f545fa00"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("47478c27-863f-4e69-9ac6-067e6d194cee"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4ce6c838-5fb5-4310-940b-04aa16cf9537"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4ed638f5-55a3-4213-8f2d-7bb1e531cbff"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5b96908c-5ec8-486f-92d7-dd5e5abf7349"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5f4df01e-8d9a-48db-9772-bfea00cb491d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5f9c8bdf-ec93-4a63-b519-b44e478ea750"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("69b79878-33e5-4982-9f8d-061149751db2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6bdabd6f-3263-4a14-872c-2a6c17d5de07"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6de4373a-c46f-44b4-b8e9-ac0b23ef5aae"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6f64603c-4185-43c6-bc2d-9ae44b0dcb71"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("74ee15f6-acf1-4870-9770-024bbcb2b8a5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("761e254b-8b02-4be8-b918-e7d28b27eec4"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("76f9e470-282b-4cb2-b5da-ed9ecb41f271"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7d2bd56a-4de1-4655-b944-7dcf37b1925a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7f997052-9a15-4a4e-a03d-9e6ef40b25e8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("805f10d2-8edd-4e7d-8b76-6cdd0ff649fb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("80d0b06b-5929-49d1-84e3-e30be21cfd64"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8876732b-cb72-4d25-a7c7-8e89a6cbbb74"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8c0bd4e2-420b-43df-b9dd-a0c9e43ee0a2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("91d593f3-cc16-4847-98bd-6c2850f6ed17"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("96b7ad8c-0693-4721-8237-1f2e42664d78"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a5322e66-5cd5-4545-ae1d-3d27ab2f9901"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a67ebc2b-851f-4ad4-a8c2-f463d985a0b0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a7f58a76-6728-4a19-93ac-591ddea7d9a6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ad5f7066-0c0a-4548-9046-3ef47a81d4a0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("af539f1c-b0f6-4459-be14-4720f56578a1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b313cffc-edc6-42d4-9195-1c17afc66334"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b4a71ae1-41f9-4a6e-8091-278842989731"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b4c1f11e-14f1-4509-972f-87b6f5277a41"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b4e6edc4-868e-48c3-a524-7b6f2d23c74d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("bf11e69e-9010-4773-a91d-bf95df55578b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("bf313f60-4bbd-4cf8-9f2f-20cd313e6c67"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c26aeea7-4e12-4b56-b709-bfffb0916495"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c5571362-18db-4aa2-be04-b061578a2f01"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c6d825f4-153d-47b2-a811-f253979b97c5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ca8b1b7e-3179-4a7f-ab6f-977039439f48"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d9e2dd13-b892-4a80-af84-8e55ac2daa1c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e27c0231-c07f-4002-95d6-953157d25a53"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e627fc44-0d33-41e2-8025-c6506ddabf0d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f66964d6-2fb5-48da-98e4-d572469db3d9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fb4a2864-0f33-4e8e-9e07-7c4d30b80e3c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fbf78960-4f03-40b5-84d9-21c503cd7209"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fc4440e8-c5af-46b4-8c5d-88098f2cb5c3"));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("0286f3ad-812c-4512-9546-26086086f814"), null, null, null, null, "Lạng Sơn" },
                    { new Guid("02b47fe6-5c30-42b2-bb2c-04f0fca94832"), null, null, null, null, "Hà Giang" },
                    { new Guid("04c5e68f-bbc3-47c8-900a-d9c775480265"), null, null, null, null, "Nam Định" },
                    { new Guid("059358f1-704f-4644-bdd2-c45ce4781417"), null, null, null, null, "Yên Bái" },
                    { new Guid("08b14fe5-5838-4897-a929-612bd662775e"), null, null, null, null, "Long An" },
                    { new Guid("12e7c647-e56e-4ff2-be33-9b3c7995fb66"), null, null, null, null, "Bạc Liêu" },
                    { new Guid("18a454ff-baa3-480c-a251-5e877bb3327a"), null, null, null, null, "Đắk Lắk" },
                    { new Guid("1900963f-bf8e-487a-b23d-ec2f07c39a41"), null, null, null, null, "Đồng Tháp" },
                    { new Guid("1e04319a-6cb3-4b01-8bdb-143d189372ab"), null, null, null, null, "Tuyên Quang" },
                    { new Guid("217b0e37-5c4b-4315-a9d2-534a3f0bc974"), null, null, null, null, "Sơn La" },
                    { new Guid("25a1d71b-d0ea-4fe5-b395-598880f310b9"), null, null, null, null, "Hải Dương" },
                    { new Guid("283d74cc-abfa-4b18-8d25-4ac8299331e0"), null, null, null, null, "Hưng Yên" },
                    { new Guid("28ef865d-0c27-4600-9030-36339b6921a6"), null, null, null, null, "Bắc Kạn" },
                    { new Guid("31e662cf-7c2e-4477-acac-21bb625481f1"), null, null, null, null, "Quảng Trị" },
                    { new Guid("339a55cd-a94a-436d-907b-41e607d472a2"), null, null, null, null, "Bình Dương" },
                    { new Guid("348f328a-727e-45ca-b645-4f0a0877bb83"), null, null, null, null, "Kiên Giang" },
                    { new Guid("35bfd1b1-6fa9-436e-9787-0a844bf9ea96"), null, null, null, null, "Bình Định" },
                    { new Guid("35d44b36-41dc-4b4a-989f-6dfeb21ce519"), null, null, null, null, "Thừa Thiên - Huế" },
                    { new Guid("39761c2a-2b98-429b-8522-3cc75cc64caf"), null, null, null, null, "Gia Lai" },
                    { new Guid("3dc46f6c-9396-45c0-876a-d1f6f545fa00"), null, null, null, null, "Cao Bằng" },
                    { new Guid("47478c27-863f-4e69-9ac6-067e6d194cee"), null, null, null, null, "Lào Cai" },
                    { new Guid("4ce6c838-5fb5-4310-940b-04aa16cf9537"), null, null, null, null, "Bình Thuận" },
                    { new Guid("4ed638f5-55a3-4213-8f2d-7bb1e531cbff"), null, null, null, null, "Điện Biên" },
                    { new Guid("5b96908c-5ec8-486f-92d7-dd5e5abf7349"), null, null, null, null, "Thái Bình" },
                    { new Guid("5f4df01e-8d9a-48db-9772-bfea00cb491d"), null, null, null, null, "Nghệ An" },
                    { new Guid("5f9c8bdf-ec93-4a63-b519-b44e478ea750"), null, null, null, null, "Phú Thọ" },
                    { new Guid("69b79878-33e5-4982-9f8d-061149751db2"), null, null, null, null, "Bắc Giang" },
                    { new Guid("6bdabd6f-3263-4a14-872c-2a6c17d5de07"), null, null, null, null, "Quảng Ngãi" },
                    { new Guid("6de4373a-c46f-44b4-b8e9-ac0b23ef5aae"), null, null, null, null, "Ninh Bình" },
                    { new Guid("6f64603c-4185-43c6-bc2d-9ae44b0dcb71"), null, null, null, null, "Quảng Ninh" },
                    { new Guid("74ee15f6-acf1-4870-9770-024bbcb2b8a5"), null, null, null, null, "Đồng Nai" },
                    { new Guid("761e254b-8b02-4be8-b918-e7d28b27eec4"), null, null, null, null, "Đắk Nông" },
                    { new Guid("76f9e470-282b-4cb2-b5da-ed9ecb41f271"), null, null, null, null, "Vĩnh Phúc" },
                    { new Guid("7d2bd56a-4de1-4655-b944-7dcf37b1925a"), null, null, null, null, "Ninh Thuận" },
                    { new Guid("7f997052-9a15-4a4e-a03d-9e6ef40b25e8"), null, null, null, null, "TP. Hồ Chí Minh" },
                    { new Guid("805f10d2-8edd-4e7d-8b76-6cdd0ff649fb"), null, null, null, null, "Thanh Hóa" },
                    { new Guid("80d0b06b-5929-49d1-84e3-e30be21cfd64"), null, null, null, null, "Bình Phước" },
                    { new Guid("8876732b-cb72-4d25-a7c7-8e89a6cbbb74"), null, null, null, null, "Cà Mau" },
                    { new Guid("8c0bd4e2-420b-43df-b9dd-a0c9e43ee0a2"), null, null, null, null, "Bến Tre" },
                    { new Guid("91d593f3-cc16-4847-98bd-6c2850f6ed17"), null, null, null, null, "Hải Phòng" },
                    { new Guid("96b7ad8c-0693-4721-8237-1f2e42664d78"), null, null, null, null, "Quảng Nam" },
                    { new Guid("a5322e66-5cd5-4545-ae1d-3d27ab2f9901"), null, null, null, null, "Phú Yên" },
                    { new Guid("a67ebc2b-851f-4ad4-a8c2-f463d985a0b0"), null, null, null, null, "Cần Thơ" },
                    { new Guid("a7f58a76-6728-4a19-93ac-591ddea7d9a6"), null, null, null, null, "Lai Châu" },
                    { new Guid("ad5f7066-0c0a-4548-9046-3ef47a81d4a0"), null, null, null, null, "Khánh Hòa" },
                    { new Guid("af539f1c-b0f6-4459-be14-4720f56578a1"), null, null, null, null, "Kon Tum" },
                    { new Guid("b313cffc-edc6-42d4-9195-1c17afc66334"), null, null, null, null, "Sóc Trăng" },
                    { new Guid("b4a71ae1-41f9-4a6e-8091-278842989731"), null, null, null, null, "Bắc Ninh" },
                    { new Guid("b4c1f11e-14f1-4509-972f-87b6f5277a41"), null, null, null, null, "Hà Nam" },
                    { new Guid("b4e6edc4-868e-48c3-a524-7b6f2d23c74d"), null, null, null, null, "Hậu Giang" },
                    { new Guid("bf11e69e-9010-4773-a91d-bf95df55578b"), null, null, null, null, "Quảng Bình" },
                    { new Guid("bf313f60-4bbd-4cf8-9f2f-20cd313e6c67"), null, null, null, null, "Đà Nẵng" },
                    { new Guid("c26aeea7-4e12-4b56-b709-bfffb0916495"), null, null, null, null, "Hòa Bình" },
                    { new Guid("c5571362-18db-4aa2-be04-b061578a2f01"), null, null, null, null, "Thái Nguyên" },
                    { new Guid("c6d825f4-153d-47b2-a811-f253979b97c5"), null, null, null, null, "Trà Vinh" },
                    { new Guid("ca8b1b7e-3179-4a7f-ab6f-977039439f48"), null, null, null, null, "An Giang" },
                    { new Guid("d9e2dd13-b892-4a80-af84-8e55ac2daa1c"), null, null, null, null, "Vĩnh Long" },
                    { new Guid("e27c0231-c07f-4002-95d6-953157d25a53"), null, null, null, null, "Bà Rịa-Vũng Tàu" },
                    { new Guid("e627fc44-0d33-41e2-8025-c6506ddabf0d"), null, null, null, null, "Lâm Đồng" },
                    { new Guid("f66964d6-2fb5-48da-98e4-d572469db3d9"), null, null, null, null, "Tiền Giang" },
                    { new Guid("fb4a2864-0f33-4e8e-9e07-7c4d30b80e3c"), null, null, null, null, "Hà Nội" },
                    { new Guid("fbf78960-4f03-40b5-84d9-21c503cd7209"), null, null, null, null, "Hà Tĩnh" },
                    { new Guid("fc4440e8-c5af-46b4-8c5d-88098f2cb5c3"), null, null, null, null, "Tây Ninh" }
                });
        }
    }
}
