using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    public partial class AjustesNaReservaFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "ReservasFlat");

            migrationBuilder.DropColumn(
                name: "Cancelada",
                table: "ReservasFlat");

            migrationBuilder.DropColumn(
                name: "EstaNaFila",
                table: "ReservasFlat");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "ReservasFlat");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "ReservasFlat");

            migrationBuilder.AlterColumn<string>(
                name: "Justificativa",
                table: "ReservasFlat",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CriadaPelaAdministracao",
                table: "ReservasFlat",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MoradorId",
                table: "ReservasFlat",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "NomeMorador",
                table: "ReservasFlat",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ReservasFlat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StatusDescricao",
                table: "ReservasFlat",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadaPelaAdministracao",
                table: "ReservasFlat");

            migrationBuilder.DropColumn(
                name: "MoradorId",
                table: "ReservasFlat");

            migrationBuilder.DropColumn(
                name: "NomeMorador",
                table: "ReservasFlat");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ReservasFlat");

            migrationBuilder.DropColumn(
                name: "StatusDescricao",
                table: "ReservasFlat");

            migrationBuilder.AlterColumn<string>(
                name: "Justificativa",
                table: "ReservasFlat",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "ReservasFlat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelada",
                table: "ReservasFlat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstaNaFila",
                table: "ReservasFlat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "ReservasFlat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "ReservasFlat",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
