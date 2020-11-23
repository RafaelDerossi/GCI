using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class CamposDeContatoDoParceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeDoResponsavel",
                table: "Parceiro",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Parceiro",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Parceiro",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fixo",
                table: "Parceiro",
                maxLength: 15,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeDoResponsavel",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "Fixo",
                table: "Parceiro");
        }
    }
}
