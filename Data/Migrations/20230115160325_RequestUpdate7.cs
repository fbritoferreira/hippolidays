using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hippolidays.Data.Migrations
{
    /// <inheritdoc />
    public partial class RequestUpdate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_AspNetUsers_ApplicationUserID",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Request",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ApplicationUserID",
                table: "Request",
                newName: "IX_Request_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_AspNetUsers_ApplicationUserId",
                table: "Request",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_AspNetUsers_ApplicationUserId",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Request",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ApplicationUserId",
                table: "Request",
                newName: "IX_Request_ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_AspNetUsers_ApplicationUserID",
                table: "Request",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
