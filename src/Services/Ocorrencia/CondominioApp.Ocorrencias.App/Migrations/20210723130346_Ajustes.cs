using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Ocorrencias.App.Migrations
{
    public partial class Ajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoradorIdFuncionarioId",
                table: "RespostasOcorrencias");

            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "RespostasOcorrencias",
                newName: "NomeDoAutor");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "RespostasOcorrencias",
                type: "varchar(1000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<Guid>(
                name: "AutorId",
                table: "RespostasOcorrencias",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ExtensaoDoArquivo",
                table: "RespostasOcorrencias",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Ocorrencias",
                type: "varchar(1000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "RespostasOcorrencias");

            migrationBuilder.DropColumn(
                name: "ExtensaoDoArquivo",
                table: "RespostasOcorrencias");

            migrationBuilder.RenameColumn(
                name: "NomeDoAutor",
                table: "RespostasOcorrencias",
                newName: "NomeUsuario");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "RespostasOcorrencias",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)");

            migrationBuilder.AddColumn<Guid>(
                name: "MoradorIdFuncionarioId",
                table: "RespostasOcorrencias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Ocorrencias",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)");
        }
    }
}
