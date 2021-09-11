using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations
{
    public partial class TempoDeIntervaloEntreReservasPorUnidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Reservas",
                type: "decimal(14,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "TempoDeIntervaloEntreReservasPorUnidade",
                table: "AreasComuns",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoDeIntervaloEntreReservasPorUnidade",
                table: "AreasComuns");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Reservas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)");
        }
    }
}
