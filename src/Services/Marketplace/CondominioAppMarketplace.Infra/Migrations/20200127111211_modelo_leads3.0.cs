using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class modelo_leads30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemDeVenda_VendedorId",
                table: "ItemDeVenda",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDeVenda_Vendedor_VendedorId",
                table: "ItemDeVenda",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDeVenda_Vendedor_VendedorId",
                table: "ItemDeVenda");

            migrationBuilder.DropIndex(
                name: "IX_ItemDeVenda_VendedorId",
                table: "ItemDeVenda");
        }
    }
}
