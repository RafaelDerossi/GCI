using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ArquivoDigital.App.Migrations
{
    public partial class Troca_UsuarioId_Por_FuncionarioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Arquivos");

            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "Arquivos",
                newName: "NomeFuncionario");

            migrationBuilder.AddColumn<Guid>(
                name: "FuncionarioId",
                table: "Arquivos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Arquivos");

            migrationBuilder.RenameColumn(
                name: "NomeFuncionario",
                table: "Arquivos",
                newName: "NomeUsuario");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Arquivos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
