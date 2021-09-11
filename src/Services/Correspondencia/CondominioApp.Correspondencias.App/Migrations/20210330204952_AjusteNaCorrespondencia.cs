using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Correspondencias.App.Migrations
{
    public partial class AjusteNaCorrespondencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Correspondencias");

            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "Correspondencias",
                newName: "NomeFuncionario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDaRetirada",
                table: "Correspondencias",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "FuncionarioId",
                table: "Correspondencias",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Correspondencias");

            migrationBuilder.RenameColumn(
                name: "NomeFuncionario",
                table: "Correspondencias",
                newName: "NomeUsuario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDaRetirada",
                table: "Correspondencias",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Correspondencias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
