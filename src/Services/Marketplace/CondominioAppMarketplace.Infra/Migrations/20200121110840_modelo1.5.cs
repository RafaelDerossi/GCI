using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class modelo15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampanhaCondominio_Campanhas_CampanhaId",
                table: "CampanhaCondominio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campanhas",
                table: "Campanhas");

            migrationBuilder.RenameTable(
                name: "Campanhas",
                newName: "Campanha");

            migrationBuilder.AddColumn<Guid>(
                name: "CondominioId",
                table: "Condominio",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeCadastro",
                table: "Campanha",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAlteracao",
                table: "Campanha",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Banner",
                table: "Campanha",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campanha",
                table: "Campanha",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ItemDeVenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    NumeroDeCliques = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    DataDeInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDeFim = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDeVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDeVenda_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    NomeDoCondominio = table.Column<string>(maxLength: 150, nullable: true),
                    NomeDoCliente = table.Column<string>(maxLength: 50, nullable: true),
                    Bloco = table.Column<string>(maxLength: 50, nullable: true),
                    Unidade = table.Column<string>(maxLength: 50, nullable: true),
                    Observacao = table.Column<string>(maxLength: 250, nullable: true),
                    Telefone = table.Column<string>(maxLength: 50, nullable: true),
                    EmailDoCliente = table.Column<string>(maxLength: 50, nullable: true),
                    ItemDeVendaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lead_ItemDeVenda_ItemDeVendaId",
                        column: x => x.ItemDeVendaId,
                        principalTable: "ItemDeVenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDeVenda_ProdutoId",
                table: "ItemDeVenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_ItemDeVendaId",
                table: "Lead",
                column: "ItemDeVendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampanhaCondominio_Campanha_CampanhaId",
                table: "CampanhaCondominio",
                column: "CampanhaId",
                principalTable: "Campanha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampanhaCondominio_Campanha_CampanhaId",
                table: "CampanhaCondominio");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "ItemDeVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campanha",
                table: "Campanha");

            migrationBuilder.DropColumn(
                name: "CondominioId",
                table: "Condominio");

            migrationBuilder.RenameTable(
                name: "Campanha",
                newName: "Campanhas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeCadastro",
                table: "Campanhas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAlteracao",
                table: "Campanhas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Banner",
                table: "Campanhas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campanhas",
                table: "Campanhas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CampanhaCondominio_Campanhas_CampanhaId",
                table: "CampanhaCondominio",
                column: "CampanhaId",
                principalTable: "Campanhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
