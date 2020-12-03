using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Correspondencias.App.Migrations
{
    public partial class CorrespondenciaDbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Correspondencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    NumeroUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bloco = table.Column<string>(type: "varchar(200)", nullable: false),
                    Visto = table.Column<bool>(nullable: false),
                    NomeRetirante = table.Column<string>(type: "varchar(200)", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(200)", nullable: true),
                    DataDaRetirada = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    NomeUsuario = table.Column<string>(type: "varchar(200)", nullable: true),
                    NomeOriginal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    NomeDoArquivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    NumeroRastreamentoCorreio = table.Column<string>(type: "varchar(200)", nullable: true),
                    DataDeChegada = table.Column<DateTime>(nullable: false),
                    QuantidadeDeAlertasFeitos = table.Column<int>(nullable: false),
                    TipoDeCorrespondencia = table.Column<string>(type: "varchar(200)", nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correspondencias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Correspondencias");
        }
    }
}
