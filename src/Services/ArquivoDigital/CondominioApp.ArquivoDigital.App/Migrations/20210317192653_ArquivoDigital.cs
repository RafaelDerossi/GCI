using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ArquivoDigital.App.Migrations
{
    public partial class ArquivoDigital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pastas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(25)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    Publica = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    NomeOriginal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    NomeDoArquivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ExtensaoDoArquivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Tamanho = table.Column<int>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    PastaId = table.Column<Guid>(nullable: false),
                    Publico = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivos_Pastas_PastaId",
                        column: x => x.PastaId,
                        principalTable: "Pastas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_PastaId",
                table: "Arquivos",
                column: "PastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pastas_Titulo_CondominioId",
                table: "Pastas",
                columns: new[] { "Titulo", "CondominioId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "Pastas");
        }
    }
}
