using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class Modelo11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContratoDescricao",
                table: "Parceiro",
                newName: "DescricaoDoContrato");

            migrationBuilder.RenameColumn(
                name: "ContratoDataDeRenovacao",
                table: "Parceiro",
                newName: "DataDeRenovacaoDoContrato");

            migrationBuilder.RenameColumn(
                name: "ContratoDataDeInicio",
                table: "Parceiro",
                newName: "DataDeInicioDoContrato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescricaoDoContrato",
                table: "Parceiro",
                newName: "ContratoDescricao");

            migrationBuilder.RenameColumn(
                name: "DataDeRenovacaoDoContrato",
                table: "Parceiro",
                newName: "ContratoDataDeRenovacao");

            migrationBuilder.RenameColumn(
                name: "DataDeInicioDoContrato",
                table: "Parceiro",
                newName: "ContratoDataDeInicio");
        }
    }
}
