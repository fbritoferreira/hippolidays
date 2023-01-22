using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hippolidays.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRequiredDataAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestType_RequestType_Id",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "RequestType_Id",
                table: "Request",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestType_RequestType_Id",
                table: "Request",
                column: "RequestType_Id",
                principalTable: "RequestType",
                principalColumn: "RequestType_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestType_RequestType_Id",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "RequestType_Id",
                table: "Request",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestType_RequestType_Id",
                table: "Request",
                column: "RequestType_Id",
                principalTable: "RequestType",
                principalColumn: "RequestType_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
