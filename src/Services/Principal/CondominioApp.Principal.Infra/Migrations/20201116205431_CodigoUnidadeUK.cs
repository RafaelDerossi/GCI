using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations
{
    public partial class CodigoUnidadeUK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Unidades_Codigo",
                table: "Unidades",
                column: "Codigo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Unidades_Codigo",
                table: "Unidades");
        }
    }
}
