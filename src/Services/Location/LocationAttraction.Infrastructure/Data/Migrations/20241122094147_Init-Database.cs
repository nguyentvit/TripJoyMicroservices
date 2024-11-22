using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocationAttraction.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LocationCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "Name" },
                values: new object[] { new Guid("662b471a-1b58-48d7-a2ea-d271bec1eb16"), null, null, "Thú vị", null, null, "Hotel" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocationCategories",
                keyColumn: "Id",
                keyValue: new Guid("662b471a-1b58-48d7-a2ea-d271bec1eb16"));
        }
    }
}
