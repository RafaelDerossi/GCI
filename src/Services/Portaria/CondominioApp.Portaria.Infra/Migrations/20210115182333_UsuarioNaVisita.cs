using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations
{
    public partial class UsuarioNaVisita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeCondomino",
                table: "Visitas",
                newName: "NomeUsuario");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Visitas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Visitas");

            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "Visitas",
                newName: "NomeCondomino");
        }
    }
}
