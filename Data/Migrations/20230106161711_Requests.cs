using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hippolidays.Data.Migrations
{
    /// <inheritdoc />
    public partial class Requests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    requesttypeid = table.Column<int>(name: "request_type_id", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    reason = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.requesttypeid);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    requestid = table.Column<int>(name: "request_id", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    useridId = table.Column<string>(name: "user_idId", type: "TEXT", nullable: true),
                    requesttypeid1 = table.Column<int>(name: "request_type_id1", type: "INTEGER", nullable: false),
                    startdate = table.Column<DateTime>(name: "start_date", type: "TEXT", nullable: false),
                    enddate = table.Column<DateTime>(name: "end_date", type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.requestid);
                    table.ForeignKey(
                        name: "FK_Request_AspNetUsers_user_idId",
                        column: x => x.useridId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Request_RequestType_request_type_id1",
                        column: x => x.requesttypeid1,
                        principalTable: "RequestType",
                        principalColumn: "request_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_request_type_id1",
                table: "Request",
                column: "request_type_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Request_user_idId",
                table: "Request",
                column: "user_idId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "RequestType");
        }
    }
}
