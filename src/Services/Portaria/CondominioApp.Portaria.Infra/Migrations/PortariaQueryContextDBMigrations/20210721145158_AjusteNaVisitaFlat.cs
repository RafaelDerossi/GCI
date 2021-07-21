using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations.PortariaQueryContextDBMigrations
{
    public partial class AjusteNaVisitaFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "VisitasFlat");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeVisitante",
                table: "VisitasFlat",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "VisitasFlat",
                type: "varchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AddColumn<string>(
                name: "NomeArquivoFotoVisitante",
                table: "VisitasFlat",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginalArquivoFotoVisitante",
                table: "VisitasFlat",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeArquivoFotoVisitante",
                table: "VisitasFlat");

            migrationBuilder.DropColumn(
                name: "NomeOriginalArquivoFotoVisitante",
                table: "VisitasFlat");

            migrationBuilder.AlterColumn<string>(
                name: "TipoDeVisitante",
                table: "VisitasFlat",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "VisitasFlat",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "VisitasFlat",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
