using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations.PrincipalQueryContextDBMigrations
{
    public partial class ContratosQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ContratoAtivo",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ContratoId",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAssinaturaContrato",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DescricaoContrato",
                table: "CondominiosFlat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkContrato",
                table: "CondominiosFlat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoPlano",
                table: "CondominiosFlat",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContratoAtivo",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ContratoId",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "DataAssinaturaContrato",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "DescricaoContrato",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "LinkContrato",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "TipoPlano",
                table: "CondominiosFlat");
        }
    }
}
