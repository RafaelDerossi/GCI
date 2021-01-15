using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations
{
    public partial class Portaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoDeDocumento = table.Column<string>(type: "varchar(200)", nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(type: "varchar(200)", nullable: false),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    NumeroUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    AndarUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    GrupoUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    VisitantePermanente = table.Column<bool>(nullable: false),
                    QrCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    TipoDeVisitante = table.Column<int>(nullable: false),
                    NomeEmpresa = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    DataDeEntrada = table.Column<DateTime>(nullable: false),
                    Terminada = table.Column<bool>(nullable: false),
                    DataDeSaida = table.Column<DateTime>(nullable: false),
                    NomeCondomino = table.Column<string>(type: "varchar(200)", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(250)", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    VisitanteId = table.Column<Guid>(nullable: false),
                    NomeVisitante = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoDeDocumentoVisitante = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoDeVisitante = table.Column<int>(nullable: false),
                    NomeEmpresaVisitante = table.Column<string>(type: "varchar(200)", nullable: true),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(type: "varchar(200)", nullable: false),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    NumeroUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    AndarUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    GrupoUnidade = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitas_Visitantes_VisitanteId",
                        column: x => x.VisitanteId,
                        principalTable: "Visitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_VisitanteId",
                table: "Visitas",
                column: "VisitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "Visitantes");
        }
    }
}
