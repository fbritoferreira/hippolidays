using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hippolidays.Data.Migrations
{
    /// <inheritdoc />
    public partial class RequestStatusApplicationUserIDUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestStatus_Request_RequestID",
                table: "RequestStatus");

            migrationBuilder.DropIndex(
                name: "IX_RequestStatus_RequestID",
                table: "RequestStatus");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "RequestStatus");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "RequestStatus",
                newName: "Request_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestStatus_Request_Id",
                table: "RequestStatus",
                column: "Request_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestStatus_Request_Request_Id",
                table: "RequestStatus",
                column: "Request_Id",
                principalTable: "Request",
                principalColumn: "Request_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestStatus_Request_Request_Id",
                table: "RequestStatus");

            migrationBuilder.DropIndex(
                name: "IX_RequestStatus_Request_Id",
                table: "RequestStatus");

            migrationBuilder.RenameColumn(
                name: "Request_Id",
                table: "RequestStatus",
                newName: "UserID");

            migrationBuilder.AddColumn<int>(
                name: "RequestID",
                table: "RequestStatus",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RequestStatus_RequestID",
                table: "RequestStatus",
                column: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestStatus_Request_RequestID",
                table: "RequestStatus",
                column: "RequestID",
                principalTable: "Request",
                principalColumn: "Request_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
