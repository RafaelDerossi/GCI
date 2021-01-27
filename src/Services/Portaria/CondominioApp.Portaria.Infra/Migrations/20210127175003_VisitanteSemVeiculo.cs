using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations
{
    public partial class VisitanteSemVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Visitantes");

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Visitas",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Visitantes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TemVeiculo",
                table: "Visitantes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "TemVeiculo",
                table: "Visitantes");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Visitas",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Visitas",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Visitantes",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Visitantes",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Visitantes",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Visitantes",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Visitantes",
                type: "varchar(7)",
                maxLength: 7,
                nullable: true);
        }
    }
}
