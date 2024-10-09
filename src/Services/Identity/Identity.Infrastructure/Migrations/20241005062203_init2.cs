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
                    { "64b81ca4-32e0-4fd6-80b8-00e1757ad5ca", null, "Admin", "ADMIN" },
                    { "d3e1df8f-ecb4-4751-bcbd-8db10041aea1", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b81ca4-32e0-4fd6-80b8-00e1757ad5ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3e1df8f-ecb4-4751-bcbd-8db10041aea1");

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
