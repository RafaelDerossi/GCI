using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations
{
    public partial class CriadorDoVisitante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CriadorId",
                table: "Visitantes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "NomeDoCriador",
                table: "Visitantes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeUsuarioDoCriador",
                table: "Visitantes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadorId",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "NomeDoCriador",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "TipoDeUsuarioDoCriador",
                table: "Visitantes");
        }
    }
}
