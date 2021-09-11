using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class Modelo12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campanha",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Banner = table.Column<string>(nullable: true),
                    DataDeInicio = table.Column<DateTime>(nullable: false),
                    DataDeFim = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    TodosOsCondominios = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampanhaCondominio",
                columns: table => new
                {
                    CondominioId = table.Column<Guid>(nullable: false),
                    CampanhaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaCondominio", x => new { x.CampanhaId, x.CondominioId });
                    table.ForeignKey(
                        name: "FK_CampanhaCondominio_Campanha_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampanhaCondominio_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaCondominio_CondominioId",
                table: "CampanhaCondominio",
                column: "CondominioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampanhaCondominio");

            migrationBuilder.DropTable(
                name: "Campanha");
        }
    }
}
