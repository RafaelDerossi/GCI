using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations
{
    public partial class AjusteNaNaFotoDeAreaComum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeDoArquivo",
                table: "FotoDaAreaComum",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginal",
                table: "FotoDaAreaComum",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeDoArquivo",
                table: "FotoDaAreaComum");

            migrationBuilder.DropColumn(
                name: "NomeOriginal",
                table: "FotoDaAreaComum");
        }
    }
}
