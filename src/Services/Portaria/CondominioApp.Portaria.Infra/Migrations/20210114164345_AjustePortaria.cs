using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations
{
    public partial class AjustePortaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Visitas",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Visitas",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeDoArquivo",
                table: "Visitas",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginal",
                table: "Visitas",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Visitas",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Visitas",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Visitas",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Visitas",
                type: "varchar(7)",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Visitantes",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Visitantes",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeDoArquivo",
                table: "Visitantes",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginal",
                table: "Visitantes",
                type: "varchar(200)",
                maxLength: 200,
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "NomeDoArquivo",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "NomeOriginal",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "NomeDoArquivo",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "NomeOriginal",
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
        }
    }
}
