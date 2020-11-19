using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppPreCadastro.App.Migrations
{
    public partial class leadIdArquivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivo_Lead_LeadId",
                table: "Arquivo");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeadId",
                table: "Arquivo",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivo_Lead_LeadId",
                table: "Arquivo",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivo_Lead_LeadId",
                table: "Arquivo");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeadId",
                table: "Arquivo",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivo_Lead_LeadId",
                table: "Arquivo",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
