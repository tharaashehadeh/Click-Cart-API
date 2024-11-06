/*using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickCart.Migrations
{
    public partial class ClickCartProductsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productsss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsss", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "productsss",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "this is PowerPlay", "PowerPlay" },
                    { 2, "this is CleanWave", "CleanWave" },
                    { 3, "this is SnackBox", "SnackBox" },
                    { 4, "this is Printer", "Printer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productsss");
        }
    }
}
*/