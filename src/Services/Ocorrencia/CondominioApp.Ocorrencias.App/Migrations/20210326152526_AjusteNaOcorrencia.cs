using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Ocorrencias.App.Migrations
{
    public partial class AjusteNaOcorrencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Ocorrencias");

            migrationBuilder.AddColumn<Guid>(
                name: "MoradorId",
                table: "Ocorrencias",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoradorId",
                table: "Ocorrencias");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Ocorrencias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
