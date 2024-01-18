using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZieDitAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddChipModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChipId = table.Column<int>(type: "int", nullable: false),
                    PosterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chips_Posters_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Posters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chips_PosterId",
                table: "Chips",
                column: "PosterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chips");
        }
    }
}
