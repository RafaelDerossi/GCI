using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations
{
    public partial class AjusteTipoDeDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoDeDocumentoVisitante",
                table: "Visitas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeDocumento",
                table: "Visitantes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoDeDocumentoVisitante",
                table: "Visitas",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "TipoDeDocumento",
                table: "Visitantes",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
