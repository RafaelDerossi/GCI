using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations
{
    public partial class ReversaAreaComumInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreasComuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    TermoDeUso = table.Column<string>(type: "varchar(500)", nullable: true),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(type: "varchar(200)", nullable: false),
                    Capacidade = table.Column<int>(nullable: false),
                    DiasPermitidos = table.Column<string>(type: "varchar(200)", nullable: false),
                    AntecedenciaMaximaEmMeses = table.Column<int>(nullable: false),
                    AntecedenciaMaximaEmDias = table.Column<int>(nullable: false),
                    AntecedenciaMinimaEmDias = table.Column<int>(nullable: false),
                    AntecedenciaMinimaParaCancelamentoEmDias = table.Column<int>(nullable: false),
                    RequerAprovacaoDeReserva = table.Column<bool>(nullable: false),
                    TemHorariosEspecificos = table.Column<bool>(nullable: false),
                    TempoDeIntervaloEntreReservas = table.Column<string>(type: "varchar(200)", nullable: true),
                    Ativa = table.Column<bool>(nullable: false),
                    TempoDeDuracaoDeReserva = table.Column<string>(nullable: true),
                    NumeroLimiteDeReservaPorUnidade = table.Column<int>(nullable: false),
                    DataInicioBloqueio = table.Column<DateTime>(nullable: true),
                    DataFimBloqueio = table.Column<DateTime>(nullable: true),
                    PermiteReservaSobreposta = table.Column<bool>(nullable: false),
                    NumeroLimiteDeReservaSobreposta = table.Column<int>(nullable: false),
                    NumeroLimiteDeReservaSobrepostaPorUnidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasComuns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periodos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    HoraInicio = table.Column<string>(type: "varchar(200)", nullable: false),
                    HoraFim = table.Column<string>(type: "varchar(200)", nullable: false),
                    AreaComumId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periodos_AreasComuns_AreaComumId",
                        column: x => x.AreaComumId,
                        principalTable: "AreasComuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    AreaComumId = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(type: "varchar(200)", nullable: true),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    NumeroUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    AndarUnidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    DescricaoGrupoUnidade = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    NomeUsuario = table.Column<string>(nullable: false),
                    DataDeRealizacao = table.Column<DateTime>(nullable: false),
                    HoraInicio = table.Column<string>(type: "varchar(200)", nullable: false),
                    HoraFim = table.Column<string>(type: "varchar(200)", nullable: false),
                    Ativa = table.Column<bool>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    EstaNaFila = table.Column<bool>(nullable: false),
                    Justificativa = table.Column<string>(type: "varchar(200)", nullable: true),
                    Origem = table.Column<string>(type: "varchar(200)", nullable: true),
                    ReservadoPelaAdministracao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_AreasComuns_AreaComumId",
                        column: x => x.AreaComumId,
                        principalTable: "AreasComuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Periodos_AreaComumId",
                table: "Periodos",
                column: "AreaComumId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AreaComumId",
                table: "Reservas",
                column: "AreaComumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Periodos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "AreasComuns");
        }
    }
}
