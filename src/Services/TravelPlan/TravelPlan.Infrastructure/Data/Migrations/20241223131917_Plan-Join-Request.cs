using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelPlan.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlanJoinRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JoinStatus",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PlanJoinRequest",
                columns: table => new
                {
                    PlanJoinRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanJoinRequest", x => new { x.PlanJoinRequestId, x.PlanId });
                    table.ForeignKey(
                        name: "FK_PlanJoinRequest_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanJoinRequest_PlanId",
                table: "PlanJoinRequest",
                column: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanJoinRequest");

            migrationBuilder.DropColumn(
                name: "JoinStatus",
                table: "Plans");
        }
    }
}
