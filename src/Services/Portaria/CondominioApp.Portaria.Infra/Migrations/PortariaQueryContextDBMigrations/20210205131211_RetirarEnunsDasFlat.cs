using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations.PortariaQueryContextDBMigrations
{
    public partial class RetirarEnunsDasFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoDeVisitante",
                table: "VisitasFlat",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TipoDeDocumentoVisitante",
                table: "VisitasFlat",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "VisitasFlat",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TipoDeVisitante",
                table: "VisitantesFlat",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TipoDeDocumento",
                table: "VisitantesFlat",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoDeVisitante",
                table: "VisitasFlat",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeDocumentoVisitante",
                table: "VisitasFlat",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "VisitasFlat",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeVisitante",
                table: "VisitantesFlat",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeDocumento",
                table: "VisitantesFlat",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }
    }
}
