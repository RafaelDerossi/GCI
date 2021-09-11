using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations.PrincipalQueryContextDBMigrations
{
    public partial class DefinicaoDeSindicoFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FuncionarioIdDoSindico",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "NomeDoSindico",
                table: "CondominiosFlat",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncionarioIdDoSindico",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "NomeDoSindico",
                table: "CondominiosFlat");
        }
    }
}
