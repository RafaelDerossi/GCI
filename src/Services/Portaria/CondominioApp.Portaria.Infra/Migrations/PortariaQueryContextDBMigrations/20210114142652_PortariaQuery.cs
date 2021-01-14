using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Portaria.Infra.Migrations.PortariaQueryContextDBMigrations
{
    public partial class PortariaQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitantesFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoDeDocumento = table.Column<string>(type: "varchar(200)", nullable: false),
                    Rg = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Foto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(type: "varchar(200)", nullable: false),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    NumeroUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    AndarUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    GrupoUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    VisitantePermanente = table.Column<bool>(nullable: false),
                    QrCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    TipoDeVisitante = table.Column<int>(nullable: false),
                    NomeEmpresa = table.Column<string>(type: "varchar(200)", nullable: true),
                    TemVeiculo = table.Column<bool>(nullable: false),
                    Placa = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    Modelo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Cor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitantesFlat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitasFlat",
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
                    Rg = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Foto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    TipoDeVisitante = table.Column<int>(nullable: false),
                    NomeEmpresaVisitante = table.Column<string>(type: "varchar(200)", nullable: true),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(type: "varchar(200)", nullable: false),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    NumeroUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    AndarUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    GrupoUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    TemVeiculo = table.Column<bool>(nullable: false),
                    Placa = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    Modelo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Cor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasFlat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitantesFlat");

            migrationBuilder.DropTable(
                name: "VisitasFlat");
        }
    }
}
