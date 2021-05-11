using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Usuarios.App.Migrations.UsuarioQueryContextDBMigrations
{
    public partial class TagEObsNoVeiculoFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "VeiculosFlat",
                type: "varchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "VeiculosFlat",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "VeiculosFlat");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "VeiculosFlat");
        }
    }
}
