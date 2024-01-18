using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProject004.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiniProject004_Flowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENGName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GERName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POLName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniProject004_Flowers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiniProject004_Flowers");
        }
    }
}
