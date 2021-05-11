using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Usuarios.App.Migrations
{
    public partial class AjusteNoMobile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Usuarios_UsuarioId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_UsuarioId",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Mobiles");

            migrationBuilder.AddColumn<Guid>(
                name: "MoradorIdFuncionadioId",
                table: "Mobiles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoradorIdFuncionadioId",
                table: "Mobiles");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Mobiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_UsuarioId",
                table: "Mobiles",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_Usuarios_UsuarioId",
                table: "Mobiles",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
