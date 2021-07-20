using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations.PortariaQueryContextDBMigrations
{
    public partial class CriadorDoVisitanteFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "VisitantesFlat");

            migrationBuilder.AddColumn<Guid>(
                name: "CriadorId",
                table: "VisitantesFlat",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "NomeArquivoFoto",
                table: "VisitantesFlat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeDoCriador",
                table: "VisitantesFlat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginalArquivoFoto",
                table: "VisitantesFlat",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeUsuarioDoCriador",
                table: "VisitantesFlat",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadorId",
                table: "VisitantesFlat");

            migrationBuilder.DropColumn(
                name: "NomeArquivoFoto",
                table: "VisitantesFlat");

            migrationBuilder.DropColumn(
                name: "NomeDoCriador",
                table: "VisitantesFlat");

            migrationBuilder.DropColumn(
                name: "NomeOriginalArquivoFoto",
                table: "VisitantesFlat");

            migrationBuilder.DropColumn(
                name: "TipoDeUsuarioDoCriador",
                table: "VisitantesFlat");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "VisitantesFlat",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
