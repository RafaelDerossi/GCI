using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Correspondencias.App.Migrations
{
    public partial class HistoricoCorrespondencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    CorrespondenciaId = table.Column<Guid>(nullable: false),
                    Acao = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: false),
                    NomeFuncionario = table.Column<string>(type: "varchar(200)", nullable: true),
                    Visto = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historico");
        }
    }
}
