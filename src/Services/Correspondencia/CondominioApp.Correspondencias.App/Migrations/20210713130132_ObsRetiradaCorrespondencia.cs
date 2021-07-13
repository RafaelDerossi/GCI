using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Correspondencias.App.Migrations
{
    public partial class ObsRetiradaCorrespondencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ObservacaoDaRetirada",
                table: "Correspondencias",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObservacaoDaRetirada",
                table: "Correspondencias");
        }
    }
}
