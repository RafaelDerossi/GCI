using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ArquivoDigital.App.Migrations
{
    public partial class AjusteNoArquivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Pastas",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Arquivos",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "Arquivos",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Arquivos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Arquivos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Arquivos");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Pastas",
                type: "varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");
        }
    }
}
