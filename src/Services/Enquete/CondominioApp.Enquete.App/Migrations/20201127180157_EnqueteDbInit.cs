using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Enquetes.App.Migrations
{
    public partial class EnqueteDbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enquetes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    CondominioNome = table.Column<string>(type: "varchar(200)", nullable: true),
                    ApenasProprietarios = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    UsuarioNome = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquetes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlternativasEnquete",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    EnqueteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativasEnquete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativasEnquete_Enquetes_EnqueteId",
                        column: x => x.EnqueteId,
                        principalTable: "Enquetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespostasEnquete",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    Unidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bloco = table.Column<string>(type: "varchar(200)", nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    UsuarioNome = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoDeUsuario = table.Column<string>(type: "varchar(200)", nullable: false),
                    AlternativaId = table.Column<Guid>(nullable: false),
                    AlternativaEnqueteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasEnquete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostasEnquete_AlternativasEnquete_AlternativaEnqueteId",
                        column: x => x.AlternativaEnqueteId,
                        principalTable: "AlternativasEnquete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternativasEnquete_EnqueteId",
                table: "AlternativasEnquete",
                column: "EnqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasEnquete_AlternativaEnqueteId",
                table: "RespostasEnquete",
                column: "AlternativaEnqueteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespostasEnquete");

            migrationBuilder.DropTable(
                name: "AlternativasEnquete");

            migrationBuilder.DropTable(
                name: "Enquetes");
        }
    }
}
