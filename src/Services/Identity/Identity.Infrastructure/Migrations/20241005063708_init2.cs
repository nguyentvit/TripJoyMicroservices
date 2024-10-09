using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99d168d6-8f60-4b77-a0e9-d596c144dec6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c919fe3f-db4e-4de6-af8f-c404f1d22e5f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75ecda09-88a1-4af8-aa55-7cc93e5cf50a", null, "Admin", "ADMIN" },
                    { "fce39955-2269-4cb3-b9da-46b46f0f5861", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75ecda09-88a1-4af8-aa55-7cc93e5cf50a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fce39955-2269-4cb3-b9da-46b46f0f5861");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99d168d6-8f60-4b77-a0e9-d596c144dec6", null, "Admin", "ADMIN" },
                    { "c919fe3f-db4e-4de6-af8f-c404f1d22e5f", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
