using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocationAttraction.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "LocationRatings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "LocationRatings");
        }
    }
}
