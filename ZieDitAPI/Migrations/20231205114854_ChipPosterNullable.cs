using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZieDitAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChipPosterNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chips_Posters_PosterId",
                table: "Chips");

            migrationBuilder.AlterColumn<int>(
                name: "PosterId",
                table: "Chips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Chips_Posters_PosterId",
                table: "Chips",
                column: "PosterId",
                principalTable: "Posters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chips_Posters_PosterId",
                table: "Chips");

            migrationBuilder.AlterColumn<int>(
                name: "PosterId",
                table: "Chips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chips_Posters_PosterId",
                table: "Chips",
                column: "PosterId",
                principalTable: "Posters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
