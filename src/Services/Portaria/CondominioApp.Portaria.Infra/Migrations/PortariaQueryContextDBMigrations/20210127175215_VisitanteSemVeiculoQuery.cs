using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations.PortariaQueryContextDBMigrations
{
    public partial class VisitanteSemVeiculoQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "VisitasFlat");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "VisitasFlat");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "VisitantesFlat");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "VisitantesFlat");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "VisitantesFlat");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "VisitantesFlat");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "VisitantesFlat");

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "VisitasFlat",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "VisitantesFlat",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "VisitasFlat");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "VisitantesFlat");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "VisitasFlat",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "VisitasFlat",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "VisitantesFlat",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "VisitantesFlat",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "VisitantesFlat",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "VisitantesFlat",
                type: "varchar(7)",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "VisitantesFlat",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
