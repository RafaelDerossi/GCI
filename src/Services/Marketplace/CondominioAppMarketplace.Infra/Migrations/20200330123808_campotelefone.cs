using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class campotelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fixo",
                table: "Parceiro",
                newName: "telefoneFixo");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Parceiro",
                newName: "TelefoneCelular");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telefoneFixo",
                table: "Parceiro",
                newName: "Fixo");

            migrationBuilder.RenameColumn(
                name: "TelefoneCelular",
                table: "Parceiro",
                newName: "Celular");
        }
    }
}
