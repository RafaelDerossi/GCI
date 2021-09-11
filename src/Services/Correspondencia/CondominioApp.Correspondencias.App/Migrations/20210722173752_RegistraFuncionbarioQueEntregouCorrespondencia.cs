using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Correspondencias.App.Migrations
{
    public partial class RegistraFuncionbarioQueEntregouCorrespondencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Correspondencias");

            migrationBuilder.RenameColumn(
                name: "NomeFuncionario",
                table: "Correspondencias",
                newName: "EntreguePorNome");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoDeVerificacao",
                table: "Correspondencias",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CadastradaPorId",
                table: "Correspondencias",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CadastradaPorNome",
                table: "Correspondencias",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EntreguePorId",
                table: "Correspondencias",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Correspondencias_CodigoDeVerificacao",
                table: "Correspondencias",
                column: "CodigoDeVerificacao",
                unique: true,
                filter: "[CodigoDeVerificacao] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Correspondencias_CodigoDeVerificacao",
                table: "Correspondencias");

            migrationBuilder.DropColumn(
                name: "CadastradaPorId",
                table: "Correspondencias");

            migrationBuilder.DropColumn(
                name: "CadastradaPorNome",
                table: "Correspondencias");

            migrationBuilder.DropColumn(
                name: "EntreguePorId",
                table: "Correspondencias");

            migrationBuilder.RenameColumn(
                name: "EntreguePorNome",
                table: "Correspondencias",
                newName: "NomeFuncionario");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoDeVerificacao",
                table: "Correspondencias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FuncionarioId",
                table: "Correspondencias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
