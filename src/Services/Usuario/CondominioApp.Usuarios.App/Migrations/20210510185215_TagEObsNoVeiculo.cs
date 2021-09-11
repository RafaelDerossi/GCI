using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Usuarios.App.Migrations
{
    public partial class TagEObsNoVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "VeiculosCondominios",
                type: "varchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "VeiculosCondominios",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "VeiculosCondominios");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "VeiculosCondominios");
        }
    }
}
