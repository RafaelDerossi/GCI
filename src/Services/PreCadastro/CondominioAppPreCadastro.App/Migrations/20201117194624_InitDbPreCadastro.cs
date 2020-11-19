using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppPreCadastro.App.Migrations
{
    public partial class InitDbPreCadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Motivo = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    NomeDoCondominio = table.Column<string>(type: "varchar(1000)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(1000)", nullable: false),
                    NomeDoSindico = table.Column<string>(type: "varchar(1000)", nullable: false),
                    EmailDoSindico = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    TelefoneDoSindico = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    TipoDeDocumento = table.Column<int>(nullable: false),
                    OutroTipoDeDocumento = table.Column<string>(type: "varchar(1000)", nullable: true),
                    NumeroDoDocumento = table.Column<string>(type: "varchar(1000)", nullable: true),
                    TipoDeUnidade = table.Column<int>(nullable: false),
                    TipoDeGrupo = table.Column<int>(nullable: false),
                    QuantidadeDeGrupos = table.Column<int>(nullable: false),
                    QuantidadeDeAndar = table.Column<int>(nullable: false),
                    QuantidadeDeUnidadesPorAndar = table.Column<int>(nullable: false),
                    QuantidadeDeUnidades = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Complemento = table.Column<string>(maxLength: 200, nullable: true),
                    Numero = table.Column<string>(maxLength: 50, nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: true),
                    Bairro = table.Column<string>(maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(maxLength: 200, nullable: true),
                    Estado = table.Column<string>(maxLength: 100, nullable: true),
                    Municipio = table.Column<string>(maxLength: 200, nullable: true),
                    LeadId = table.Column<Guid>(nullable: false),
                    Plano = table.Column<int>(nullable: false),
                    Transferido = table.Column<bool>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condominio_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    NomeOriginalDoArquivo = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(1000)", nullable: false),
                    LeadId = table.Column<Guid>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivo_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Arquivo_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivo_CondominioId",
                table: "Arquivo",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivo_LeadId",
                table: "Arquivo",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Condominio_LeadId",
                table: "Condominio",
                column: "LeadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "Condominio");

            migrationBuilder.DropTable(
                name: "Lead");
        }
    }
}
