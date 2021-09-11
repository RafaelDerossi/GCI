using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations.PortariaQueryContextDBMigrations
{
    public partial class AjusteTipoDeDocumentoQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoDeDocumentoVisitante",
                table: "VisitasFlat",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeDocumento",
                table: "VisitantesFlat",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoDeDocumentoVisitante",
                table: "VisitasFlat",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "TipoDeDocumento",
                table: "VisitantesFlat",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
