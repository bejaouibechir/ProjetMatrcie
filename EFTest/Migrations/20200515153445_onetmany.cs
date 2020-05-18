using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTest.Migrations
{
    public partial class onetmany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auteur_Livre_LivreId",
                table: "Auteur");

            migrationBuilder.DropIndex(
                name: "IX_Auteur_LivreId",
                table: "Auteur");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auteur_LivreId",
                table: "Auteur",
                column: "LivreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Auteur_Livre_LivreId",
                table: "Auteur",
                column: "LivreId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
