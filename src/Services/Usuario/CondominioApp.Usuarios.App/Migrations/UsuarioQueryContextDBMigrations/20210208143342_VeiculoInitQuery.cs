using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Usuarios.App.Migrations.UsuarioQueryContextDBMigrations
{
    public partial class VeiculoInitQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VeiculosFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    VeiculoId = table.Column<Guid>(nullable: false),
                    Placa = table.Column<string>(type: "varchar(7)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(200)", nullable: true),
                    Cor = table.Column<string>(type: "varchar(30)", nullable: true),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    NomeUsuario = table.Column<string>(nullable: true),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    NumeroUnidade = table.Column<string>(nullable: true),
                    AndarUnidade = table.Column<string>(nullable: true),
                    GrupoUnidade = table.Column<string>(nullable: true),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculosFlat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeiculosFlat");
        }
    }
}
