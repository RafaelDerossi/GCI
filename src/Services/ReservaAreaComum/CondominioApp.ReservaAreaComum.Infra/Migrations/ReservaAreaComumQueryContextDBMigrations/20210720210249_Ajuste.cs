using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    public partial class Ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotoDaAreaComum");

            migrationBuilder.DropTable(
                name: "NomeArquivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FotoDaAreaComum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaComumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondominioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lixeira = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoDaAreaComum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NomeArquivo",
                columns: table => new
                {
                    AreaComumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtensaoDoArquivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    NomeDoArquivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    NomeOriginal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomeArquivo", x => x.AreaComumId);
                });
        }
    }
}
