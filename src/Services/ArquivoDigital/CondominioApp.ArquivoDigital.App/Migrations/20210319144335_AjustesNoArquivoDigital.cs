using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ArquivoDigital.App.Migrations
{
    public partial class AjustesNoArquivoDigital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaDaPastaDeSistema",
                table: "Pastas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PastaDoSistema",
                table: "Pastas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "AnexadoPorId",
                table: "Arquivos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaDaPastaDeSistema",
                table: "Pastas");

            migrationBuilder.DropColumn(
                name: "PastaDoSistema",
                table: "Pastas");

            migrationBuilder.DropColumn(
                name: "AnexadoPorId",
                table: "Arquivos");
        }
    }
}
