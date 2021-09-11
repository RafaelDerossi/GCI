using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class Modelo13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampanhaCondominio_Campanha_CampanhaId",
                table: "CampanhaCondominio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campanha",
                table: "Campanha");

            migrationBuilder.RenameTable(
                name: "Campanha",
                newName: "Campanhas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campanhas",
                table: "Campanhas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(maxLength: 250, nullable: true),
                    Chamada = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Link = table.Column<string>(maxLength: 50, nullable: true),
                    ParceiroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Parceiro_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotoDoProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    NomeOriginal = table.Column<string>(maxLength: 50, nullable: true),
                    NomeArquivo = table.Column<string>(maxLength: 50, nullable: true),
                    Extensao = table.Column<string>(nullable: true),
                    Principal = table.Column<bool>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoDoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotoDoProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FotoDoProduto_ProdutoId",
                table: "FotoDoProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ParceiroId",
                table: "Produto",
                column: "ParceiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampanhaCondominio_Campanhas_CampanhaId",
                table: "CampanhaCondominio",
                column: "CampanhaId",
                principalTable: "Campanhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampanhaCondominio_Campanhas_CampanhaId",
                table: "CampanhaCondominio");

            migrationBuilder.DropTable(
                name: "FotoDoProduto");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campanhas",
                table: "Campanhas");

            migrationBuilder.RenameTable(
                name: "Campanhas",
                newName: "Campanha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campanha",
                table: "Campanha",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CampanhaCondominio_Campanha_CampanhaId",
                table: "CampanhaCondominio",
                column: "CampanhaId",
                principalTable: "Campanha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
