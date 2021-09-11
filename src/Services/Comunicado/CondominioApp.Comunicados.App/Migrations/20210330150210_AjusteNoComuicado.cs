using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Comunicados.App.Migrations
{
    public partial class AjusteNoComuicado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Comunicados");

            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "Comunicados",
                newName: "NomeFuncionario");

            migrationBuilder.AddColumn<Guid>(
                name: "FuncionarioId",
                table: "Comunicados",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Comunicados");

            migrationBuilder.RenameColumn(
                name: "NomeFuncionario",
                table: "Comunicados",
                newName: "NomeUsuario");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Comunicados",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
