using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations
{
    public partial class InicioPrincipalBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: true),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    NomeOriginal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    NomeDoArquivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    RefereciaId = table.Column<int>(nullable: true),
                    LinkGeraBoleto = table.Column<string>(type: "varchar(200)", nullable: true),
                    BoletoFolder = table.Column<string>(type: "varchar(200)", nullable: true),
                    UrlWebServer = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Portaria = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    PortariaMorador = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Classificado = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    ClassificadoMorador = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Mural = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    MuralMorador = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Chat = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    ChatMorador = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Reserva = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    ReservaNaPortaria = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Ocorrencia = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    OcorrenciaMorador = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Correspondencia = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    CorrespondenciaNaPortaria = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    LimiteTempoReserva = table.Column<bool>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(200)", nullable: false),
                    Andar = table.Column<string>(type: "varchar(200)", nullable: false),
                    Vagas = table.Column<int>(nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Ramal = table.Column<string>(type: "varchar(200)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(200)", nullable: true),
                    GrupoId = table.Column<Guid>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidades_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Unidades_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_CondominioId",
                table: "Grupos",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_CondominioId",
                table: "Unidades",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_GrupoId",
                table: "Unidades",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Condominios");
        }
    }
}
