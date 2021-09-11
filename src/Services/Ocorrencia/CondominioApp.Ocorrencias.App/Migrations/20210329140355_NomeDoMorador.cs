using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Ocorrencias.App.Migrations
{
    public partial class NomeDoMorador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "RespostasOcorrencias");

            migrationBuilder.AddColumn<Guid>(
                name: "MoradorIdFuncionarioId",
                table: "RespostasOcorrencias",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "NomeMorador",
                table: "Ocorrencias",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoradorIdFuncionarioId",
                table: "RespostasOcorrencias");

            migrationBuilder.DropColumn(
                name: "NomeMorador",
                table: "Ocorrencias");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "RespostasOcorrencias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
