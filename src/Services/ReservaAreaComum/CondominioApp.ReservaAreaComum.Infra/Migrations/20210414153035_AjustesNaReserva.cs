using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations
{
    public partial class AjustesNaReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Cancelada",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "EstaNaFila",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Reservas");

            migrationBuilder.AlterColumn<string>(
                name: "Justificativa",
                table: "Reservas",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CriadaPelaAdministracao",
                table: "Reservas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MoradorId",
                table: "Reservas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "NomeMorador",
                table: "Reservas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadaPelaAdministracao",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "MoradorId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "NomeMorador",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservas");

            migrationBuilder.AlterColumn<string>(
                name: "Justificativa",
                table: "Reservas",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Reservas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelada",
                table: "Reservas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstaNaFila",
                table: "Reservas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Reservas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
