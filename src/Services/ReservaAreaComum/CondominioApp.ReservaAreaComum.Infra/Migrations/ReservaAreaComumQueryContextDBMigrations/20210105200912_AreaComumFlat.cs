using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    public partial class AreaComumFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreasComunsFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    TermoDeUso = table.Column<string>(nullable: true),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(nullable: true),
                    Capacidade = table.Column<int>(nullable: false),
                    DiasPermitidos = table.Column<string>(nullable: true),
                    AntecedenciaMaximaEmMeses = table.Column<int>(nullable: false),
                    AntecedenciaMaximaEmDias = table.Column<int>(nullable: false),
                    AntecedenciaMinimaEmDias = table.Column<int>(nullable: false),
                    AntecedenciaMinimaParaCancelamentoEmDias = table.Column<int>(nullable: false),
                    RequerAprovacaoDeReserva = table.Column<bool>(nullable: false),
                    TemHorariosEspecificos = table.Column<bool>(nullable: false),
                    TempoDeIntervaloEntreReservas = table.Column<string>(nullable: true),
                    Ativa = table.Column<bool>(nullable: false),
                    TempoDeDuracaoDeReserva = table.Column<string>(nullable: true),
                    NumeroLimiteDeReservaPorUnidade = table.Column<int>(nullable: false),
                    DataInicioBloqueio = table.Column<DateTime>(nullable: true),
                    DataFimBloqueio = table.Column<DateTime>(nullable: true),
                    PermiteReservaSobreposta = table.Column<bool>(nullable: false),
                    NumeroLimiteDeReservaSobreposta = table.Column<int>(nullable: false),
                    NumeroLimiteDeReservaSobrepostaPorUnidade = table.Column<int>(nullable: false),
                    TemIntervaloFixoEntreReservas = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasComunsFlat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodosFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    HoraInicio = table.Column<string>(nullable: true),
                    HoraFim = table.Column<string>(nullable: true),
                    AreaComumId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    AreaComumFlatId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodosFlat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodosFlat_AreasComunsFlat_AreaComumFlatId",
                        column: x => x.AreaComumFlatId,
                        principalTable: "AreasComunsFlat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodosFlat_AreaComumFlatId",
                table: "PeriodosFlat",
                column: "AreaComumFlatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodosFlat");

            migrationBuilder.DropTable(
                name: "AreasComunsFlat");
        }
    }
}
