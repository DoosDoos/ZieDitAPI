using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZieDitAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeChipName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChipId",
                table: "Chips");

            migrationBuilder.AddColumn<string>(
                name: "ChipName",
                table: "Chips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChipName",
                table: "Chips");

            migrationBuilder.AddColumn<int>(
                name: "ChipId",
                table: "Chips",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
