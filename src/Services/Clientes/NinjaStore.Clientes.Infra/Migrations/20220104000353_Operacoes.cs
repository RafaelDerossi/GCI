using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCI.Acoes.Infra.Migrations
{
    public partial class Operacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    CodigoDaAcao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    DataDaOperacao = table.Column<DateTime>(nullable: false),
                    CustoDaOperacao = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operacoes");
        }
    }
}
