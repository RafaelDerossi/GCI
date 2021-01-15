using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations.PortariaQueryContextDBMigrations
{
    public partial class UsuarioNaVisitaFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeCondomino",
                table: "VisitasFlat",
                newName: "NomeUsuario");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "VisitasFlat",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "VisitasFlat");

            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "VisitasFlat",
                newName: "NomeCondomino");
        }
    }
}
