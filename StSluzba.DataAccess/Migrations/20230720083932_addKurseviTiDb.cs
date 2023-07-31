using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StSluzba.DataAccess.Migrations
{
    public partial class addKurseviTiDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kursevi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bodovi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kursevi",
                columns: new[] { "Id", "Bodovi", "Naziv" },
                values: new object[] { 1, 5, "Racunarska grafika" });

            migrationBuilder.InsertData(
                table: "Kursevi",
                columns: new[] { "Id", "Bodovi", "Naziv" },
                values: new object[] { 2, 5, "Multimedijalni sistemi" });

            migrationBuilder.InsertData(
                table: "Kursevi",
                columns: new[] { "Id", "Bodovi", "Naziv" },
                values: new object[] { 3, 6, "Osnove programiranja" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kursevi");
        }
    }
}
