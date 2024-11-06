using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAccess.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFriendv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FriendUserSentId",
                table: "UserSentFriendRequest",
                newName: "UserReceiverId");

            migrationBuilder.RenameColumn(
                name: "FriendUserRequestId",
                table: "UserFriendRequest",
                newName: "UserSenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserReceiverId",
                table: "UserSentFriendRequest",
                newName: "FriendUserSentId");

            migrationBuilder.RenameColumn(
                name: "UserSenderId",
                table: "UserFriendRequest",
                newName: "FriendUserRequestId");
        }
    }
}
