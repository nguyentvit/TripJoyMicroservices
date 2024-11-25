using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelPlan.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlanLocationEstimatedStartDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "PlanLocations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedStartDate",
                table: "PlanLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("0815b31e-4329-4ca5-88b4-2a137c09bdf1"), null, null, null, null, "Tiền Giang" },
                    { new Guid("0a56c5b7-8283-4c22-a555-81c8c77efb9f"), null, null, null, null, "Hà Nội" },
                    { new Guid("0a97deff-644d-49f2-a710-70e1c54dc4ce"), null, null, null, null, "Bình Thuận" },
                    { new Guid("0b97fdd6-4fce-4339-86db-19ada04ddabe"), null, null, null, null, "Lai Châu" },
                    { new Guid("0d57d40b-90dd-43a1-be67-c3d01a33a90d"), null, null, null, null, "Thái Nguyên" },
                    { new Guid("0f44eeb8-2eb6-4d9c-b2f9-e17fa0645307"), null, null, null, null, "Phú Yên" },
                    { new Guid("1685de7f-9f41-4620-9ee0-a133a802d3fc"), null, null, null, null, "Đắk Lắk" },
                    { new Guid("1eadd14f-31ae-4046-abca-3cfdd5bf43e3"), null, null, null, null, "Thành phố Hồ Chí Minh" },
                    { new Guid("2488ec0f-0086-428d-88c2-8b4551636b31"), null, null, null, null, "Lào Cai" },
                    { new Guid("2c3f37aa-57af-4d55-85a5-3074d13bd40c"), null, null, null, null, "Ninh Thuận" },
                    { new Guid("2fc19558-5ff8-4b39-be3d-950de1928b93"), null, null, null, null, "Thái Bình" },
                    { new Guid("2fc5e4cd-eddb-44a2-a792-56292abea2db"), null, null, null, null, "Đà Nẵng" },
                    { new Guid("3380b8f5-e854-4e72-8021-c6f2146655f0"), null, null, null, null, "Kiên Giang" },
                    { new Guid("35370d91-daba-4423-aa4f-7f555eb5427f"), null, null, null, null, "Hòa Bình" },
                    { new Guid("35555d6d-2292-4c5e-aa64-79c00560d358"), null, null, null, null, "Bắc Kạn" },
                    { new Guid("39daa34e-b0b1-44ed-b54e-84123563bd9d"), null, null, null, null, "Nam Định" },
                    { new Guid("3ddceedf-a16b-4fac-b92f-f2e7211f878a"), null, null, null, null, "Lâm Đồng" },
                    { new Guid("41fda8a9-66a2-4749-8f6f-5772edf88d5b"), null, null, null, null, "Cao Bằng" },
                    { new Guid("43f04efd-9498-416e-bdf8-e474eb98c48e"), null, null, null, null, "Bình Dương" },
                    { new Guid("4938e4e5-f624-41bf-b3f6-6b4dbc50b246"), null, null, null, null, "Tuyên Quang" },
                    { new Guid("4942b167-0eaa-4776-bfb3-43ad85e190b5"), null, null, null, null, "Trà Vinh" },
                    { new Guid("4d065da1-a78b-4f0e-97c6-0bb5d3f55ffb"), null, null, null, null, "Nghệ An" },
                    { new Guid("526fa4ef-e9d8-4575-84fd-c0f2ef9d96ea"), null, null, null, null, "Thái Bình" },
                    { new Guid("5dc9d3aa-7c7a-4d71-b481-746ab155e1e8"), null, null, null, null, "Phú Thọ" },
                    { new Guid("5dffc807-aadd-4f33-98ba-35209158f41f"), null, null, null, null, "Yên Bái" },
                    { new Guid("5ecd8fa9-468b-418c-afe5-5e9098ab0659"), null, null, null, null, "Hà Tĩnh" },
                    { new Guid("64930e47-3e18-4878-9830-a86ca00e51df"), null, null, null, null, "Hải Dương" },
                    { new Guid("66b66c13-269f-4f6e-a673-2e085e9c8109"), null, null, null, null, "Vĩnh Long" },
                    { new Guid("6980124c-aaa3-4807-a188-846ef6b7f090"), null, null, null, null, "Hà Giang" },
                    { new Guid("6b08f721-a3cf-412f-9bb0-1ee200e1b3d2"), null, null, null, null, "Đồng Nai" },
                    { new Guid("7b916c3f-04a4-43af-a7bd-d128a3a36293"), null, null, null, null, "Sơn La" },
                    { new Guid("7c12d94c-83bc-40aa-8912-83c9e6ca25c7"), null, null, null, null, "Cà Mau" },
                    { new Guid("7ce6ebe3-f3c8-40da-8dbe-cf533aed0077"), null, null, null, null, "Thanh Hóa" },
                    { new Guid("823d7032-ac29-4904-81a3-37e2612c1db2"), null, null, null, null, "Quảng Ninh" },
                    { new Guid("84661e95-3027-42b6-977b-bd204eaa8564"), null, null, null, null, "Đắk Nông" },
                    { new Guid("89d35cc2-8cdf-41b4-97d0-4dd8b5199ae3"), null, null, null, null, "An Giang" },
                    { new Guid("8cc96e0f-07be-4874-ac23-e6297fcacc9b"), null, null, null, null, "Bà Rịa - Vũng Tàu" },
                    { new Guid("8e1c7a51-6505-45b7-b9c5-291aadbfba45"), null, null, null, null, "Bến Tre" },
                    { new Guid("8e4e0f95-55ab-48dd-9aa7-70b6d63b435c"), null, null, null, null, "Cần Thơ" },
                    { new Guid("94983e70-6088-43bf-a69f-5e3afde1dc0a"), null, null, null, null, "Bình Phước" },
                    { new Guid("a690946d-3046-494b-9641-b2ac361b51e0"), null, null, null, null, "Quảng Ngãi" },
                    { new Guid("a7e2cc11-2ffa-40b4-be70-f2f253f33886"), null, null, null, null, "Tây Ninh" },
                    { new Guid("a9891668-008e-4f51-98c3-60c4ade39847"), null, null, null, null, "Khánh Hòa" },
                    { new Guid("a995c907-1b5b-4fbb-bfd7-781b1ef3ce87"), null, null, null, null, "Sóc Trăng" },
                    { new Guid("ad09d53a-fe5b-45aa-a1d6-4afbcd673bfc"), null, null, null, null, "Hậu Giang" },
                    { new Guid("af7f2569-0efe-47ad-871b-471f53aa5388"), null, null, null, null, "Bình Định" },
                    { new Guid("b2346372-4d2e-4597-a96f-b12d2f6c66fb"), null, null, null, null, "Quảng Trị" },
                    { new Guid("b4dc9369-10e3-4a37-9d7e-e6cfb609e40d"), null, null, null, null, "Đồng Tháp" },
                    { new Guid("b9dfdaca-bb4f-4921-adfe-0f5173ad456e"), null, null, null, null, "Hải Phòng" },
                    { new Guid("ba149ec2-c97c-46d2-86d1-be3af2ab008e"), null, null, null, null, "Thừa Thiên Huế" },
                    { new Guid("bf64f2ac-a7fc-40a8-b4ee-317cf80a0e5e"), null, null, null, null, "Bắc Giang" },
                    { new Guid("c5556c9e-d51f-4bbf-a190-40ebf3ffc8b7"), null, null, null, null, "Gia Lai" },
                    { new Guid("c869d581-d3bc-4fc7-9c65-6f9bc6776324"), null, null, null, null, "Hà Nam" },
                    { new Guid("d05bbf91-5e47-4155-bb29-e3ebc56e18ca"), null, null, null, null, "Bạc Liêu" },
                    { new Guid("d1e3c73a-02ab-463c-965d-5ba1cf74857f"), null, null, null, null, "Sóc Trăng" },
                    { new Guid("d2cfa81a-87fd-4fc2-bfd4-05eb5939110d"), null, null, null, null, "Bắc Ninh" },
                    { new Guid("db5a59f0-5d3a-4307-a5ee-9898f9f781c9"), null, null, null, null, "Quảng Nam" },
                    { new Guid("db62b353-8aa3-414b-8b0f-d9a6f1ca1ae3"), null, null, null, null, "Long An" },
                    { new Guid("e21ab1b1-d75d-4d7f-af0a-109e015e6b10"), null, null, null, null, "Kon Tum" },
                    { new Guid("e4775923-9725-497d-ad4e-225772eb7e68"), null, null, null, null, "Vĩnh Phúc" },
                    { new Guid("e79a15f0-2a14-4fb8-8299-f2f866beedc9"), null, null, null, null, "Ninh Bình" },
                    { new Guid("e874352a-3a44-4398-ba8a-a3fb2b69adf7"), null, null, null, null, "Hưng Yên" },
                    { new Guid("ef6b32ff-ffbe-43ea-9f16-9c379e029f90"), null, null, null, null, "Quảng Bình" },
                    { new Guid("f520027b-7e86-47b3-8fe3-676498c6929d"), null, null, null, null, "Điện Biên" },
                    { new Guid("fab88a89-58a2-4813-b24c-99d15978622a"), null, null, null, null, "Lạng Sơn" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0815b31e-4329-4ca5-88b4-2a137c09bdf1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0a56c5b7-8283-4c22-a555-81c8c77efb9f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0a97deff-644d-49f2-a710-70e1c54dc4ce"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0b97fdd6-4fce-4339-86db-19ada04ddabe"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0d57d40b-90dd-43a1-be67-c3d01a33a90d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0f44eeb8-2eb6-4d9c-b2f9-e17fa0645307"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1685de7f-9f41-4620-9ee0-a133a802d3fc"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1eadd14f-31ae-4046-abca-3cfdd5bf43e3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2488ec0f-0086-428d-88c2-8b4551636b31"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2c3f37aa-57af-4d55-85a5-3074d13bd40c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2fc19558-5ff8-4b39-be3d-950de1928b93"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2fc5e4cd-eddb-44a2-a792-56292abea2db"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3380b8f5-e854-4e72-8021-c6f2146655f0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("35370d91-daba-4423-aa4f-7f555eb5427f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("35555d6d-2292-4c5e-aa64-79c00560d358"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("39daa34e-b0b1-44ed-b54e-84123563bd9d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3ddceedf-a16b-4fac-b92f-f2e7211f878a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("41fda8a9-66a2-4749-8f6f-5772edf88d5b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("43f04efd-9498-416e-bdf8-e474eb98c48e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4938e4e5-f624-41bf-b3f6-6b4dbc50b246"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4942b167-0eaa-4776-bfb3-43ad85e190b5"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4d065da1-a78b-4f0e-97c6-0bb5d3f55ffb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("526fa4ef-e9d8-4575-84fd-c0f2ef9d96ea"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5dc9d3aa-7c7a-4d71-b481-746ab155e1e8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5dffc807-aadd-4f33-98ba-35209158f41f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5ecd8fa9-468b-418c-afe5-5e9098ab0659"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("64930e47-3e18-4878-9830-a86ca00e51df"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("66b66c13-269f-4f6e-a673-2e085e9c8109"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6980124c-aaa3-4807-a188-846ef6b7f090"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6b08f721-a3cf-412f-9bb0-1ee200e1b3d2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7b916c3f-04a4-43af-a7bd-d128a3a36293"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7c12d94c-83bc-40aa-8912-83c9e6ca25c7"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7ce6ebe3-f3c8-40da-8dbe-cf533aed0077"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("823d7032-ac29-4904-81a3-37e2612c1db2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("84661e95-3027-42b6-977b-bd204eaa8564"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("89d35cc2-8cdf-41b4-97d0-4dd8b5199ae3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8cc96e0f-07be-4874-ac23-e6297fcacc9b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8e1c7a51-6505-45b7-b9c5-291aadbfba45"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8e4e0f95-55ab-48dd-9aa7-70b6d63b435c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("94983e70-6088-43bf-a69f-5e3afde1dc0a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a690946d-3046-494b-9641-b2ac361b51e0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a7e2cc11-2ffa-40b4-be70-f2f253f33886"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a9891668-008e-4f51-98c3-60c4ade39847"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a995c907-1b5b-4fbb-bfd7-781b1ef3ce87"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ad09d53a-fe5b-45aa-a1d6-4afbcd673bfc"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("af7f2569-0efe-47ad-871b-471f53aa5388"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b2346372-4d2e-4597-a96f-b12d2f6c66fb"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b4dc9369-10e3-4a37-9d7e-e6cfb609e40d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b9dfdaca-bb4f-4921-adfe-0f5173ad456e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ba149ec2-c97c-46d2-86d1-be3af2ab008e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("bf64f2ac-a7fc-40a8-b4ee-317cf80a0e5e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c5556c9e-d51f-4bbf-a190-40ebf3ffc8b7"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c869d581-d3bc-4fc7-9c65-6f9bc6776324"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d05bbf91-5e47-4155-bb29-e3ebc56e18ca"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d1e3c73a-02ab-463c-965d-5ba1cf74857f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d2cfa81a-87fd-4fc2-bfd4-05eb5939110d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("db5a59f0-5d3a-4307-a5ee-9898f9f781c9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("db62b353-8aa3-414b-8b0f-d9a6f1ca1ae3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e21ab1b1-d75d-4d7f-af0a-109e015e6b10"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e4775923-9725-497d-ad4e-225772eb7e68"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e79a15f0-2a14-4fb8-8299-f2f866beedc9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e874352a-3a44-4398-ba8a-a3fb2b69adf7"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ef6b32ff-ffbe-43ea-9f16-9c379e029f90"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f520027b-7e86-47b3-8fe3-676498c6929d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fab88a89-58a2-4813-b24c-99d15978622a"));

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "PlanLocations");

            migrationBuilder.DropColumn(
                name: "EstimatedStartDate",
                table: "PlanLocations");

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
        }
    }
}
