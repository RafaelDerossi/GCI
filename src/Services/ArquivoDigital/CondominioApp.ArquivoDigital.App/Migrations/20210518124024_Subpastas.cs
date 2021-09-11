using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ArquivoDigital.App.Migrations
{
    public partial class Subpastas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PastaId",
                table: "Pastas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "PastaRaiz",
                table: "Pastas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Pastas_PastaId",
                table: "Pastas",
                column: "PastaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastas_Pastas_PastaId",
                table: "Pastas",
                column: "PastaId",
                principalTable: "Pastas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastas_Pastas_PastaId",
                table: "Pastas");

            migrationBuilder.DropIndex(
                name: "IX_Pastas_PastaId",
                table: "Pastas");

            migrationBuilder.DropColumn(
                name: "PastaId",
                table: "Pastas");

            migrationBuilder.DropColumn(
                name: "PastaRaiz",
                table: "Pastas");
        }
    }
}
