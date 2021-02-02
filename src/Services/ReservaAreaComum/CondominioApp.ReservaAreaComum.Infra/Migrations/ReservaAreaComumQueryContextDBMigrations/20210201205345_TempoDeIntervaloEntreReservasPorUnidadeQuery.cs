using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    public partial class TempoDeIntervaloEntreReservasPorUnidadeQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempoDeIntervaloEntreReservasPorUnidade",
                table: "AreasComunsFlat",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoDeIntervaloEntreReservasPorUnidade",
                table: "AreasComunsFlat");
        }
    }
}
