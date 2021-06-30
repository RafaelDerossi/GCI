using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class CategoriaParceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Parceiro_ParceiroId",
                table: "Vendedor");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParceiroId",
                table: "Vendedor",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Parceiro",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "Parceiro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Parceiro_ParceiroId",
                table: "Vendedor",
                column: "ParceiroId",
                principalTable: "Parceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Parceiro_ParceiroId",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Parceiro");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParceiroId",
                table: "Vendedor",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Parceiro",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Parceiro_ParceiroId",
                table: "Vendedor",
                column: "ParceiroId",
                principalTable: "Parceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
