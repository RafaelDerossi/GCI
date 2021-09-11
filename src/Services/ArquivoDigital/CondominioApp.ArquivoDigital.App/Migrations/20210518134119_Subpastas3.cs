using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ArquivoDigital.App.Migrations
{
    public partial class Subpastas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PastaMaeId",
                table: "Pastas",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PastaMaeId",
                table: "Pastas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
