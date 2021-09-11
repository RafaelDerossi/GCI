using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Automacao.App.Migrations
{
    public partial class DispositivosWebkooksLigado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ligado",
                table: "DispositivoWebhook",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ligado",
                table: "DispositivoWebhook");
        }
    }
}
