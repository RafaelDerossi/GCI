using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppPreCadastro.App.Migrations
{
    public partial class PrecadastroLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoDePlano",
                table: "Lead",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDePlano",
                table: "Lead");
        }
    }
}
