using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class telefonemovel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "TelefoneCelular",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "telefoneFixo",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "WhatsappFixo",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Lead");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Vendedor",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroFixo",
                table: "Parceiro",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Parceiro",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Lead",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "NumeroFixo",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Lead");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Vendedor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefoneCelular",
                table: "Parceiro",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefoneFixo",
                table: "Parceiro",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WhatsappFixo",
                table: "Parceiro",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Lead",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
