using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Comunicados.App.Migrations
{
    public partial class ComunicadoBdInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comunicados",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataDeRealizacao = table.Column<DateTime>(nullable: true),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    NomeUsuario = table.Column<string>(type: "varchar(200)", nullable: true),
                    Visibilidade = table.Column<int>(nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    TemAnexos = table.Column<bool>(nullable: false),
                    CriadoPelaAdministradora = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunicados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Numero = table.Column<string>(type: "varchar(200)", nullable: false),
                    Andar = table.Column<string>(type: "varchar(200)", nullable: false),
                    GrupoId = table.Column<Guid>(nullable: false),
                    DescricaoGrupo = table.Column<string>(type: "varchar(200)", nullable: true),
                    ComunicadoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidades_Comunicados_ComunicadoId",
                        column: x => x.ComunicadoId,
                        principalTable: "Comunicados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_ComunicadoId",
                table: "Unidades",
                column: "ComunicadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Comunicados");
        }
    }
}
