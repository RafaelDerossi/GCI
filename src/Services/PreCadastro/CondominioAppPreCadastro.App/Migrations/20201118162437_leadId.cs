using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppPreCadastro.App.Migrations
{
    public partial class leadId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condominio_Lead_LeadId",
                table: "Condominio");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeadId",
                table: "Condominio",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Condominio_Lead_LeadId",
                table: "Condominio",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condominio_Lead_LeadId",
                table: "Condominio");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeadId",
                table: "Condominio",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Condominio_Lead_LeadId",
                table: "Condominio",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
