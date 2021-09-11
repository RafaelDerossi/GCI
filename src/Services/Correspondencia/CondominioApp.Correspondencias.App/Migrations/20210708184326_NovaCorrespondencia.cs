using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Correspondencias.App.Migrations
{
    public partial class NovaCorrespondencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeOriginal",
                table: "Correspondencias",
                newName: "NomeOriginalFotoRetirante");

            migrationBuilder.RenameColumn(
                name: "NomeDoArquivo",
                table: "Correspondencias",
                newName: "NomeArquivoFotoRetirante");

            migrationBuilder.AddColumn<string>(
                name: "CodigoDeVerificacao",
                table: "Correspondencias",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnviarNotificacao",
                table: "Correspondencias",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                table: "Correspondencias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeDoArquivoFoto",
                table: "Correspondencias",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginalFoto",
                table: "Correspondencias",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoDeVerificacao",
                table: "Correspondencias");

            migrationBuilder.DropColumn(
                name: "EnviarNotificacao",
                table: "Correspondencias");

            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "Correspondencias");

            migrationBuilder.DropColumn(
                name: "NomeDoArquivoFoto",
                table: "Correspondencias");

            migrationBuilder.DropColumn(
                name: "NomeOriginalFoto",
                table: "Correspondencias");

            migrationBuilder.RenameColumn(
                name: "NomeOriginalFotoRetirante",
                table: "Correspondencias",
                newName: "NomeOriginal");

            migrationBuilder.RenameColumn(
                name: "NomeArquivoFotoRetirante",
                table: "Correspondencias",
                newName: "NomeDoArquivo");
        }
    }
}
