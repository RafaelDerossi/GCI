using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations.PortariaQueryContextDBMigrations
{
    public partial class DescricaoStatusParaVisitaFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescricaoStatus",
                table: "VisitasFlat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoTipoDeDocumentoVisitante",
                table: "VisitasFlat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoTipoDeVisitante",
                table: "VisitasFlat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoTipoDeDocumento",
                table: "VisitantesFlat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoTipoDeVisitante",
                table: "VisitantesFlat",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoStatus",
                table: "VisitasFlat");

            migrationBuilder.DropColumn(
                name: "DescricaoTipoDeDocumentoVisitante",
                table: "VisitasFlat");

            migrationBuilder.DropColumn(
                name: "DescricaoTipoDeVisitante",
                table: "VisitasFlat");

            migrationBuilder.DropColumn(
                name: "DescricaoTipoDeDocumento",
                table: "VisitantesFlat");

            migrationBuilder.DropColumn(
                name: "DescricaoTipoDeVisitante",
                table: "VisitantesFlat");
        }
    }
}
