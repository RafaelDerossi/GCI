using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    public partial class ChaveEstrangeiraNoPeriodoFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodosFlat_AreasComunsFlat_AreaComumFlatId",
                table: "PeriodosFlat");

            migrationBuilder.DropColumn(
                name: "AreaComumId",
                table: "PeriodosFlat");

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaComumFlatId",
                table: "PeriodosFlat",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodosFlat_AreasComunsFlat_AreaComumFlatId",
                table: "PeriodosFlat",
                column: "AreaComumFlatId",
                principalTable: "AreasComunsFlat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodosFlat_AreasComunsFlat_AreaComumFlatId",
                table: "PeriodosFlat");

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaComumFlatId",
                table: "PeriodosFlat",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "AreaComumId",
                table: "PeriodosFlat",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodosFlat_AreasComunsFlat_AreaComumFlatId",
                table: "PeriodosFlat",
                column: "AreaComumFlatId",
                principalTable: "AreasComunsFlat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
