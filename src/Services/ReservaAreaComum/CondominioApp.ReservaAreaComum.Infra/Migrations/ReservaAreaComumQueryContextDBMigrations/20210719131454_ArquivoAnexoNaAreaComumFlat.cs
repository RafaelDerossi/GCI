using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    public partial class ArquivoAnexoNaAreaComumFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeArquivoAnexo",
                table: "AreasComunsFlat",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginalArquivoAnexo",
                table: "AreasComunsFlat",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FotoDaAreaComum",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    AreaComumId = table.Column<Guid>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoDaAreaComum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NomeArquivo",
                columns: table => new
                {
                    AreaComumId = table.Column<Guid>(nullable: false),
                    NomeOriginal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    NomeDoArquivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ExtensaoDoArquivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomeArquivo", x => x.AreaComumId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotoDaAreaComum");

            migrationBuilder.DropTable(
                name: "NomeArquivo");

            migrationBuilder.DropColumn(
                name: "NomeArquivoAnexo",
                table: "AreasComunsFlat");

            migrationBuilder.DropColumn(
                name: "NomeOriginalArquivoAnexo",
                table: "AreasComunsFlat");
        }
    }
}
