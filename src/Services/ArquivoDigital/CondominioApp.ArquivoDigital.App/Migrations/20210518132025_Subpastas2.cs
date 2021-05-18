using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ArquivoDigital.App.Migrations
{
    public partial class Subpastas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "PastaMaeId",
                table: "Pastas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pastas_PastaMaeId",
                table: "Pastas",
                column: "PastaMaeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastas_Pastas_PastaMaeId",
                table: "Pastas",
                column: "PastaMaeId",
                principalTable: "Pastas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastas_Pastas_PastaMaeId",
                table: "Pastas");

            migrationBuilder.DropIndex(
                name: "IX_Pastas_PastaMaeId",
                table: "Pastas");

            migrationBuilder.DropColumn(
                name: "PastaMaeId",
                table: "Pastas");

            migrationBuilder.AddColumn<Guid>(
                name: "PastaId",
                table: "Pastas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
