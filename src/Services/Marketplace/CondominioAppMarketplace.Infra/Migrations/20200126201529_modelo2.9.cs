using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class modelo29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanha_ItemDeVenda_Id",
                table: "Campanha");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_ItemDeVendaId",
                table: "Campanha",
                column: "ItemDeVendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanha_ItemDeVenda_ItemDeVendaId",
                table: "Campanha",
                column: "ItemDeVendaId",
                principalTable: "ItemDeVenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanha_ItemDeVenda_ItemDeVendaId",
                table: "Campanha");

            migrationBuilder.DropIndex(
                name: "IX_Campanha_ItemDeVendaId",
                table: "Campanha");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanha_ItemDeVenda_Id",
                table: "Campanha",
                column: "Id",
                principalTable: "ItemDeVenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
