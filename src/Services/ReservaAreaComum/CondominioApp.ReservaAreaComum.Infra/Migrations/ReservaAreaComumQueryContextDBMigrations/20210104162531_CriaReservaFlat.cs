using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    public partial class CriaReservaFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservasFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    AreaComumId = table.Column<Guid>(nullable: false),
                    NomeAreaComum = table.Column<string>(type: "varchar(200)", nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(type: "varchar(200)", nullable: false),
                    Capacidade = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(type: "varchar(240)", nullable: true),
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
                    Preco = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    EstaNaFila = table.Column<bool>(nullable: false),
                    Cancelada = table.Column<bool>(nullable: false),
                    Justificativa = table.Column<string>(type: "varchar(200)", nullable: true),
                    Origem = table.Column<string>(type: "varchar(200)", nullable: true),
                    ReservadoPelaAdministracao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasFlat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservasFlat");
        }
    }
}
