using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Usuarios.App.Migrations.UsuarioQueryContextDBMigrations
{
    public partial class AjusteNoUsuarioQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TpUsuario",
                table: "MoradoresFlat");

            migrationBuilder.DropColumn(
                name: "TpUsuario",
                table: "FuncionariosFlat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TpUsuario",
                table: "MoradoresFlat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TpUsuario",
                table: "FuncionariosFlat",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
