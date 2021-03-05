using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Enquetes.App.Migrations
{
    public partial class NovoCampoOrdemNaAlternativaEnquete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ordem",
                table: "AlternativasEnquete",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "AlternativasEnquete");
        }
    }
}
