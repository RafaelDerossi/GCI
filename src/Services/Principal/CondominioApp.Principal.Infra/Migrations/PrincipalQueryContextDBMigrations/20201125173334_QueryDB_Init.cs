using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations.PrincipalQueryContextDBMigrations
{
    public partial class QueryDB_Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CondominiosFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(18)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    LogoMarca = table.Column<string>(type: "varchar(200)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Complemento = table.Column<string>(maxLength: 200, nullable: true),
                    Numero = table.Column<string>(maxLength: 50, nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: true),
                    Bairro = table.Column<string>(maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(maxLength: 200, nullable: true),
                    Estado = table.Column<string>(maxLength: 100, nullable: true),
                    RefereciaId = table.Column<int>(nullable: true),
                    LinkGeraBoleto = table.Column<string>(type: "varchar(200)", nullable: true),
                    BoletoFolder = table.Column<string>(type: "varchar(200)", nullable: true),
                    UrlWebServer = table.Column<string>(type: "varchar(255)", nullable: true),
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
                    table.PrimaryKey("PK_CondominiosFlat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GruposFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    CondominioCnpj = table.Column<string>(type: "varchar(18)", nullable: false),
                    CondominioNome = table.Column<string>(type: "varchar(200)", nullable: false),
                    CondominioLogoMarca = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposFlat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(200)", nullable: false),
                    Andar = table.Column<string>(type: "varchar(15)", nullable: false),
                    Vagas = table.Column<int>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    Ramal = table.Column<string>(type: "varchar(200)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(200)", nullable: true),
                    GrupoId = table.Column<Guid>(nullable: false),
                    GrupoDescricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    CondominioCnpj = table.Column<string>(type: "varchar(18)", nullable: true),
                    CondominioNome = table.Column<string>(type: "varchar(200)", nullable: false),
                    CondominioLogoMarca = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesFlat", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesFlat_Codigo",
                table: "UnidadesFlat",
                column: "Codigo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondominiosFlat");

            migrationBuilder.DropTable(
                name: "GruposFlat");

            migrationBuilder.DropTable(
                name: "UnidadesFlat");
        }
    }
}
