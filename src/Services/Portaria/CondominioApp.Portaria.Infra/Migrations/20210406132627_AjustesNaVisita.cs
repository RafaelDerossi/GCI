using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations
{
    public partial class AjustesNaVisita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AndarUnidade",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "GrupoUnidade",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "NomeCondominio",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "NumeroUnidade",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "AndarUnidade",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "GrupoUnidade",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "NomeCondominio",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "NumeroUnidade",
                table: "Visitantes");

            migrationBuilder.AddColumn<Guid>(
                name: "MoradorId",
                table: "Visitas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoradorId",
                table: "Visitas");

            migrationBuilder.AddColumn<string>(
                name: "AndarUnidade",
                table: "Visitas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GrupoUnidade",
                table: "Visitas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeCondominio",
                table: "Visitas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "Visitas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroUnidade",
                table: "Visitas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Visitas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AndarUnidade",
                table: "Visitantes",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GrupoUnidade",
                table: "Visitantes",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeCondominio",
                table: "Visitantes",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroUnidade",
                table: "Visitantes",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }
    }
}
