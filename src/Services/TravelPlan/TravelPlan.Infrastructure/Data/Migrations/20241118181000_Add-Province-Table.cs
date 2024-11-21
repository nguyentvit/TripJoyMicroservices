using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelPlan.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProvinceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Plans");

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceEndId",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceStartId",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanIds_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanIds_ProvinceId",
                table: "PlanIds",
                column: "ProvinceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanIds");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropColumn(
                name: "ProvinceEndId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ProvinceStartId",
                table: "Plans");

            migrationBuilder.AddColumn<string>(
                name: "Visibility",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
