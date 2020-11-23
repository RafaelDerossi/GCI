using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class whatsapp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Whatsapp",
                table: "Vendedor",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Whatsapp",
                table: "Parceiro",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WhatsappFixo",
                table: "Parceiro",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Whatsapp",
                table: "Lead",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Whatsapp",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "Whatsapp",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "WhatsappFixo",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "Whatsapp",
                table: "Lead");
        }
    }
}
