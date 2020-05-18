using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTest.Migrations
{
    public partial class onetoone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(nullable: true),
                    AuteurId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auteur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    LivreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auteur_Livre_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auteur_LivreId",
                table: "Auteur",
                column: "LivreId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auteur");

            migrationBuilder.DropTable(
                name: "Livre");
        }
    }
}
