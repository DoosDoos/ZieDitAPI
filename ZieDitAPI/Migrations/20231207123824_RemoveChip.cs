using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZieDitAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveChip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chips");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosterId = table.Column<int>(type: "int", nullable: true),
                    ChipName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chips_Posters_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Posters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chips_PosterId",
                table: "Chips",
                column: "PosterId");
        }
    }
}
