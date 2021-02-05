using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Comunicados.App.Migrations
{
    public partial class unidadeComunicado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_Comunicados_ComunicadoId",
                table: "Unidades");

            migrationBuilder.AlterColumn<Guid>(
                name: "ComunicadoId",
                table: "Unidades",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidades_Comunicados_ComunicadoId",
                table: "Unidades",
                column: "ComunicadoId",
                principalTable: "Comunicados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_Comunicados_ComunicadoId",
                table: "Unidades");

            migrationBuilder.AlterColumn<Guid>(
                name: "ComunicadoId",
                table: "Unidades",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Unidades_Comunicados_ComunicadoId",
                table: "Unidades",
                column: "ComunicadoId",
                principalTable: "Comunicados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
