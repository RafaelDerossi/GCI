using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Enquetes.App.Migrations
{
    public partial class AjusteNoRespostaEnquete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostasEnquete_AlternativasEnquete_AlternativaEnqueteId",
                table: "RespostasEnquete");

            migrationBuilder.DropColumn(
                name: "AlternativaId",
                table: "RespostasEnquete");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlternativaEnqueteId",
                table: "RespostasEnquete",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasEnquete_AlternativasEnquete_AlternativaEnqueteId",
                table: "RespostasEnquete",
                column: "AlternativaEnqueteId",
                principalTable: "AlternativasEnquete",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostasEnquete_AlternativasEnquete_AlternativaEnqueteId",
                table: "RespostasEnquete");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlternativaEnqueteId",
                table: "RespostasEnquete",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "AlternativaId",
                table: "RespostasEnquete",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasEnquete_AlternativasEnquete_AlternativaEnqueteId",
                table: "RespostasEnquete",
                column: "AlternativaEnqueteId",
                principalTable: "AlternativasEnquete",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
