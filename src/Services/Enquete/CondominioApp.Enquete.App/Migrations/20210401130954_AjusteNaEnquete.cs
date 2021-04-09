using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Enquetes.App.Migrations
{
    public partial class AjusteNaEnquete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Enquetes");

            migrationBuilder.RenameColumn(
                name: "UsuarioNome",
                table: "Enquetes",
                newName: "FuncionarioNome");

            migrationBuilder.AddColumn<Guid>(
                name: "FuncionarioId",
                table: "Enquetes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Enquetes");

            migrationBuilder.RenameColumn(
                name: "FuncionarioNome",
                table: "Enquetes",
                newName: "UsuarioNome");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Enquetes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
