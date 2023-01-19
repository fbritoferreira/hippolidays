using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hippolidays.Data.Migrations
{
    /// <inheritdoc />
    public partial class HolidaysRemaining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HolidaysRemaining",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HolidaysRemaining",
                table: "AspNetUsers");
        }
    }
}
