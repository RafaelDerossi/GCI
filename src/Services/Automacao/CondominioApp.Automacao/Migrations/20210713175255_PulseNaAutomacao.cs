using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Automacao.App.Migrations
{
    public partial class PulseNaAutomacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PulseLigado",
                table: "DispositivoWebhook",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TempoDoPulse",
                table: "DispositivoWebhook",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PulseLigado",
                table: "DispositivoWebhook");

            migrationBuilder.DropColumn(
                name: "TempoDoPulse",
                table: "DispositivoWebhook");
        }
    }
}
