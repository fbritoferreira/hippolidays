using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hippolidays.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusNavigationPropToRequestTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestStatus_ID",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Request",
                newName: "RequestStatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ID",
                table: "Request",
                newName: "IX_Request_RequestStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestStatus_RequestStatusID",
                table: "Request",
                column: "RequestStatusID",
                principalTable: "RequestStatus",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestStatus_RequestStatusID",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "RequestStatusID",
                table: "Request",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Request_RequestStatusID",
                table: "Request",
                newName: "IX_Request_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestStatus_ID",
                table: "Request",
                column: "ID",
                principalTable: "RequestStatus",
                principalColumn: "ID");
        }
    }
}
