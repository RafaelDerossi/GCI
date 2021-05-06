using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    public partial class DataDeAlteracaoNaHistoricoReservaFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeAlteracao",
                table: "HistoricoReservaFlat",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeAlteracao",
                table: "HistoricoReservaFlat");
        }
    }
}
