using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTest.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Auteur_AuteurId",
                table: "Livre");

            migrationBuilder.DropIndex(
                name: "IX_Livre_AuteurId",
                table: "Livre");

            migrationBuilder.AddColumn<int>(
                name: "LivreId",
                table: "Auteur",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LivreAuteur",
                columns: table => new
                {
                    LivreId = table.Column<int>(nullable: false),
                    AuteurId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivreAuteur", x => new { x.AuteurId, x.LivreId });
                    table.ForeignKey(
                        name: "FK_LivreAuteur_Auteur_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreAuteur_Livre_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivreAuteur_LivreId",
                table: "LivreAuteur",
                column: "LivreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivreAuteur");

            migrationBuilder.DropColumn(
                name: "LivreId",
                table: "Auteur");

            migrationBuilder.CreateIndex(
                name: "IX_Livre_AuteurId",
                table: "Livre",
                column: "AuteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livre_Auteur_AuteurId",
                table: "Livre",
                column: "AuteurId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
