using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Ocorrencias.App.Migrations
{
    public partial class RespostaOcorrencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataResposta",
                table: "Ocorrencias");

            migrationBuilder.DropColumn(
                name: "Parecer",
                table: "Ocorrencias");

            migrationBuilder.CreateTable(
                name: "RespostasOcorrencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    OcorrenciaId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoAutor = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    NomeUsuario = table.Column<string>(type: "varchar(200)", nullable: true),
                    Visto = table.Column<bool>(nullable: false),
                    NomeOriginal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    NomeDoArquivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasOcorrencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostasOcorrencias_Ocorrencias_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespostasOcorrencias_OcorrenciaId",
                table: "RespostasOcorrencias",
                column: "OcorrenciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespostasOcorrencias");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataResposta",
                table: "Ocorrencias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parecer",
                table: "Ocorrencias",
                type: "varchar(200)",
                nullable: true);
        }
    }
}
