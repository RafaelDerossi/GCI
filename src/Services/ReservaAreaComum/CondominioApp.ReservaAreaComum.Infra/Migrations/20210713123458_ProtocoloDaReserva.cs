using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations
{
    public partial class ProtocoloDaReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Protocolo",
                table: "Reservas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Protocolo",
                table: "Reservas");
        }
    }
}
